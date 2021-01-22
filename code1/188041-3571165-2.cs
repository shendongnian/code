    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    namespace ConsoleApplication1 {
        class Program {
            static string ToHex(byte[] value) {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in value)
                    sb.AppendFormat("{0:x2}", b);
                return sb.ToString();
            }
            static string Encode(long value, byte[] key) {
                byte[] InputBuffer = new byte[16];
                byte[] OutputBuffer;
                unsafe {
                    fixed (byte* pInputBuffer = InputBuffer) {
                        ((long*)pInputBuffer)[0] = value;
                        ((long*)pInputBuffer)[1] = value;
                    }
                }
                AesCryptoServiceProvider Aes = new AesCryptoServiceProvider();
                Aes.Mode = CipherMode.ECB;
                Aes.Padding = PaddingMode.None;
                Aes.Key = key;
                using (ICryptoTransform Encryptor = Aes.CreateEncryptor()) {
                    OutputBuffer = Encryptor.TransformFinalBlock(InputBuffer, 0, 16);
                }
                Aes.Clear();
                return ToHex(OutputBuffer);
            }
            static bool TryDecode(string value, byte[] key, out long result) {
                byte[] InputBuffer = new byte[16];
                byte[] OutputBuffer;
                for (int i = 0; i < 16; i++) {
                    InputBuffer[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
                }
                AesCryptoServiceProvider Aes = new AesCryptoServiceProvider();
                Aes.Mode = CipherMode.ECB;
                Aes.Padding = PaddingMode.None;
                Aes.Key = key;
                using (ICryptoTransform Decryptor = Aes.CreateDecryptor()) {
                    OutputBuffer = Decryptor.TransformFinalBlock(InputBuffer, 0, 16);
                }
                Aes.Clear();
                unsafe {
                    fixed (byte* pOutputBuffer = OutputBuffer) {
                        //return ((long*)pOutputBuffer)[0];
                        if (((long*)pOutputBuffer)[0] == ((long*)pOutputBuffer)[1]) {
                            result = ((long*)pOutputBuffer)[0];
                            return true;
                        }
                        else {
                            result = 0;
                            return false;
                        }
                    }
                }
            }
            static void Main(string[] args) {
                long NumberToEncode = (new Random()).Next();
                Console.WriteLine("Number to encode = {0}.", NumberToEncode);
                byte[] Key = new byte[24];
                (new RNGCryptoServiceProvider()).GetBytes(Key);
                Console.WriteLine("Key to encode with is {0}.", ToHex(Key));
                string EncodedValue = Encode(NumberToEncode, Key);
                Console.WriteLine("The encoded value is {0}.", EncodedValue);
                long DecodedValue;
                bool Success = TryDecode(EncodedValue, Key, out DecodedValue);
                if (Success) {
                    Console.WriteLine("Successfully decoded the encoded value.");
                    Console.WriteLine("The decoded result is {0}.", DecodedValue);
                }
                else
                    Console.WriteLine("Failed to decode encoded value. Invalid result.");
            }
        }
    }
