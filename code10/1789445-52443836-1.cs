    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace SO
    {
        [TestClass]
        public class UnitTest1
        {
            private const string TabBase64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            private static readonly byte[] BackFrom64 = CreateBackFrom64();
    
            private static byte[] CreateBackFrom64()
            {
                var backFrom64 = new byte[128];
    
                for (var i = 0; i < backFrom64.Length; ++i)
                    backFrom64[i] = 0xff;
    
                for (byte i = 0; i < TabBase64.Length; i++)
                {
                    var c = TabBase64[i];
                    backFrom64[c] = i;
                }
    
                return backFrom64;
            }
    
            int FromBase64(byte[] Output, string Input, int BufSize, int MaxSize)
            {
                int xut, txut;
                int i, t, k, shift;
                byte c;
                int dr, dr1;
    
                xut = txut = t = 0;
                dr = 0;
    
                var iInput = 0;
                var iOutput = 0;
    
                for (i = 0; i < BufSize; ++i)
                {
                    c = (byte)Input[iInput++];
                    if (c == '=')
                    {
                        break;
                    }
                    if ((c = BackFrom64[c]) == 0xff)
                    {
                        continue;
                    }
                    dr1 = c;
                    shift = (32 - (6 * (t + 1)));
                    dr1 <<= shift;
                    dr |= dr1;
                    t++;
                    if (t == 4)
                    {
                        t = 0;
                        for (k = 0; k < 3; ++k)
                        {
                            dr1 = dr;
                            dr1 >>= (32 - (8 * (k + 1)));
                            dr1 &= 0xff;
                            Output[iOutput++] = (byte)dr1;
                            if (++txut >= MaxSize)
                            {
                                return (-1);
                            }
                        }
                        dr = 0;
                    }
                }
                if (t > 0)
                {
                    for (k = 0; k < (t - 1); ++k)
                    {
                        dr1 = dr;
                        dr1 >>= (32 - (8 * (k + 1)));
                        dr1 &= 0xff;
                        Output[iOutput++] = (byte)dr1;
                        if (++txut >= MaxSize)
                        {
                            return (-1);
                        }
                    }
                }
                return (txut);
            }
            [TestMethod]
            public void TestMethod1()
            {
                var input = @"lWXtYpNpwBBXoLmcuktDqg==";
                var expectedOutput = "AC0105E92ED496ACD373D7496B76C1C8";
    
                var converted = new byte[(input.Length * 2) / 3];
    
                var result = FromBase64(converted, input, input.Length, int.MaxValue);
    
                Assert.AreNotEqual(-1, result, "result is valid");
    
                Assert.AreEqual(
                    BitConverter.ToString(converted).Replace("-",""),
                    BitConverter.ToString(Convert.FromBase64String(input)).Replace("-",""),
                    "Supplied algorithm matches standard algorithm" );
    
                Assert.AreEqual(
                    expectedOutput,
                    BitConverter.ToString(converted).Replace("-",""),
                    "Supplied algorithm matches expected output" );
            }
        }
    }
