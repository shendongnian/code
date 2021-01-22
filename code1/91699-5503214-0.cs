    using System;
    
    namespace Encryption
    {
        public enum XXTEAMode
        {
            Encrypt,
            Decrypt
        }
    
        static public class XXTEA
        {
            static public byte[] Code(byte[] data, uint[] k, XXTEAMode mode)
            {
                uint[] v = new uint[(int)Math.Ceiling((float)data.Length / 4)];
                Buffer.BlockCopy(data, 0, v, 0, data.Length);
    
                unchecked
                {
                    const uint DELTA = 0x9e3779b9;
                    uint y = 0, z = 0, sum = 0, p = 0, rounds = 0, e = 0;
                    int n = v.Length;
                    Func<uint> MX = () => (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (k[(p & 3) ^ e] ^ z)));
    
                    if (mode == XXTEAMode.Encrypt)
                    {
                        rounds = (uint)(6 + 52 / n);
                        z = v[n - 1];
                        do
                        {
                            sum += DELTA;
                            e = (sum >> 2) & 3;
                            for (p = 0; p < n - 1; p++)
                            {
                                y = v[p + 1];
                                z = v[p] += MX();
                            }
                            y = v[0];
                            z = v[n - 1] += MX();
                        } while (--rounds > 0);
                    }
                    else
                    {
                        rounds = (uint)(6 + 52 / n);
                        sum = rounds * DELTA;
                        y = v[0];
                        do
                        {
                            e = (sum >> 2) & 3;
                            for (p = (uint)(n - 1); p > 0; p--)
                            {
                                z = v[p - 1];
                                y = v[p] -= MX();
                            }
                            z = v[n - 1];
                            y = v[0] -= MX();
                        } while ((sum -= DELTA) != 0);
                    }
                }
    
                byte[] rvl = new byte[v.Length * 4];
                Buffer.BlockCopy(v, 0, rvl, 0, rvl.Length);
                return rvl;
            }
        }
    }
