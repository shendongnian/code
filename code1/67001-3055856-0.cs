    Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes(name), 4096);
    key = rfc2898.GetBytes(32);
    public class Rfc2898DeriveBytes : DeriveBytes
        {
            const int BlockSize = 20;
            uint block;
            byte[] buffer;
            int endIndex;
            readonly HMACSHA1 hmacsha1;
            uint iterations;
            byte[] salt;
            int startIndex;
            public Rfc2898DeriveBytes(string password, int saltSize)
                : this(password, saltSize, 1000)
            {
            }
            public Rfc2898DeriveBytes(string password, byte[] salt)
                : this(password, salt, 1000)
            {
            }
            public Rfc2898DeriveBytes(string password, int saltSize, int iterations)
            {
                if (saltSize < 0)
                {
                    throw new ArgumentOutOfRangeException("saltSize");
                }
                byte[] data = new byte[saltSize];
                new RNGCryptoServiceProvider().GetBytes(data);
                Salt = data;
                IterationCount = iterations;
                hmacsha1 = new HMACSHA1(new UTF8Encoding(false).GetBytes(password));
                Initialize();
            }
            public Rfc2898DeriveBytes(string password, byte[] salt, int iterations) : this(new UTF8Encoding(false).GetBytes(password), salt, iterations)
            {
            }
            public Rfc2898DeriveBytes(byte[] password, byte[] salt, int iterations)
            {
                Salt = salt;
                IterationCount = iterations;
                hmacsha1 = new HMACSHA1(password);
                Initialize();
            }
            static byte[] Int(uint i)
            {
                byte[] bytes = BitConverter.GetBytes(i);
                byte[] buffer2 = new byte[] {bytes[3], bytes[2], bytes[1], bytes[0]};
                if (!BitConverter.IsLittleEndian)
                {
                    return bytes;
                }
                return buffer2;
            }
            byte[] DeriveKey()
            {
                byte[] inputBuffer = Int(block);
                hmacsha1.TransformBlock(salt, 0, salt.Length, salt, 0);
                hmacsha1.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                byte[] hash = hmacsha1.Hash;
                hmacsha1.Initialize();
                byte[] buffer3 = hash;
                for (int i = 2; i <= iterations; i++)
                {
                    hash = hmacsha1.ComputeHash(hash);
                    for (int j = 0; j < BlockSize; j++)
                    {
                        buffer3[j] = (byte) (buffer3[j] ^ hash[j]);
                    }
                }
                block++;
                return buffer3;
            }
            public override byte[] GetBytes(int bytesToGet)
            {
                if (bytesToGet <= 0)
                {
                    throw new ArgumentOutOfRangeException("bytesToGet");
                }
                byte[] dst = new byte[bytesToGet];
                int dstOffset = 0;
                int count = endIndex - startIndex;
                if (count > 0)
                {
                    if (bytesToGet < count)
                    {
                        Buffer.BlockCopy(buffer, startIndex, dst, 0, bytesToGet);
                        startIndex += bytesToGet;
                        return dst;
                    }
                    Buffer.BlockCopy(buffer, startIndex, dst, 0, count);
                    startIndex = endIndex = 0;
                    dstOffset += count;
                }
                while (dstOffset < bytesToGet)
                {
                    byte[] src = DeriveKey();
                    int num3 = bytesToGet - dstOffset;
                    if (num3 > BlockSize)
                    {
                        Buffer.BlockCopy(src, 0, dst, dstOffset, BlockSize);
                        dstOffset += BlockSize;
                    }
                    else
                    {
                        Buffer.BlockCopy(src, 0, dst, dstOffset, num3);
                        dstOffset += num3;
                        Buffer.BlockCopy(src, num3, buffer, startIndex, BlockSize - num3);
                        endIndex += BlockSize - num3;
                        return dst;
                    }
                }
                return dst;
            }
            void Initialize()
            {
                if (buffer != null)
                {
                    Array.Clear(buffer, 0, buffer.Length);
                }
                buffer = new byte[BlockSize];
                block = 1;
                startIndex = endIndex = 0;
            }
            public override void Reset()
            {
                Initialize();
            }
            public int IterationCount
            {
                get
                {
                    return (int) iterations;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    iterations = (uint) value;
                    Initialize();
                }
            }
            public byte[] Salt
            {
                get
                {
                    return (byte[]) salt.Clone();
                }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    salt = (byte[]) value.Clone();
                    Initialize();
                }
            }
        }
