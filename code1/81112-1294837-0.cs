    using System.Security.Cryptography;
            SHA512 hash;
            try
            {
                hash = new SHA512Cng( );
            }
            catch ( PlatformNotSupportedException )
            {
                hash = SHA512.Create( );
            }
