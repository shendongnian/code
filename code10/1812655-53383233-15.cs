    public class CertificateProtectorTokenProvider<TUser, TKey> : IUserTokenProvider<TUser, TKey>
        where TUser : class, IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private IDataProtector protector;
        public CertificateProtectorTokenProvider(IDataProtector protector)
        {
            this.protector = protector;
        }
        public virtual async Task<string> GenerateAsync(string purpose, UserManager<TUser, TKey> manager, TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var ms = new MemoryStream();
            using (var writer = new BinaryWriter(ms, new UTF8Encoding(false, true), true))
            {
                writer.Write(DateTimeOffset.UtcNow.UtcTicks);
                writer.Write(Convert.ToInt32(user.Id));
                writer.Write(purpose ?? "");
                string stamp = null;
                if (manager.SupportsUserSecurityStamp)
                {
                    stamp = await manager.GetSecurityStampAsync(user.Id);
                }
                writer.Write(stamp ?? "");
            }
            var protectedBytes = protector.Protect(ms.ToArray());
            return Convert.ToBase64String(protectedBytes);
        }
        public virtual async Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser, TKey> manager, TUser user)
        {
            try
            {
                var unprotectedData = protector.Unprotect(Convert.FromBase64String(token));
                var ms = new MemoryStream(unprotectedData);
                using (var reader = new BinaryReader(ms, new UTF8Encoding(false, true), true))
                {
                    var creationTime = new DateTimeOffset(reader.ReadInt64(), TimeSpan.Zero);
                    var expirationTime = creationTime + TimeSpan.FromDays(1);
                    if (expirationTime < DateTimeOffset.UtcNow)
                    {
                        return false;
                    }
                    var userId = reader.ReadInt32();
                    var actualUser = await manager.FindByIdAsync(user.Id);
                    var actualUserId = Convert.ToInt32(actualUser.Id);
                    if (userId != actualUserId)
                    {
                        return false;
                    }
                    var purp = reader.ReadString();
                    if (!string.Equals(purp, purpose))
                    {
                        return false;
                    }
                    var stamp = reader.ReadString();
                    if (reader.PeekChar() != -1)
                    {
                        return false;
                    }
                    if (manager.SupportsUserSecurityStamp)
                    {
                        return stamp == await manager.GetSecurityStampAsync(user.Id);
                    }
                    return stamp == "";
                }
            }
            catch (Exception e)
            {
                // Do not leak exception
            }
            return false;
        }
        public Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsValidProviderForUserAsync(UserManager<TUser, TKey> manager, TUser user)
        {
            throw new NotImplementedException();
        }
    }
    public class CertificateProtectionProvider : IDataProtectionProvider
    {
        public IDataProtector Create(params string[] purposes)
        {
            return new CertificateDataProtector(purposes);
        }
    }
    public class CertificateDataProtector : IDataProtector
    {
        private readonly string[] _purposes;
        private X509Certificate2 cert;
        public CertificateDataProtector(string[] purposes)
        {
            _purposes = purposes;
            X509Store store = null;
            store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            var certificateThumbprint = ConfigurationManager.AppSettings["CertificateThumbprint"].ToUpper();
            cert = store.Certificates.Cast<X509Certificate2>()
                .FirstOrDefault(x => x.GetCertHashString()
                    .Equals(certificateThumbprint, StringComparison.InvariantCultureIgnoreCase));
        }
        public byte[] Protect(byte[] userData)
        {
            using (RSA rsa = cert.GetRSAPrivateKey())
            {
                // OAEP allows for multiple hashing algorithms, what was formermly just "OAEP" is
                // now OAEP-SHA1.
                return rsa.Encrypt(userData, RSAEncryptionPadding.OaepSHA1);
            }
        }
        public byte[] Unprotect(byte[] protectedData)
        {
            // GetRSAPrivateKey returns an object with an independent lifetime, so it should be
            // handled via a using statement.
            using (RSA rsa = cert.GetRSAPrivateKey())
            {
                return rsa.Decrypt(protectedData, RSAEncryptionPadding.OaepSHA1);
            }
        }
    }
