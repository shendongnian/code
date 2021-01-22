                using System;
                using System.Collections.Generic;
                using System.Text;
                using System.Text.RegularExpressions;  // This is for password validation
                using System.Security.Cryptography;
                using System.Configuration;  // This is where the hash functions reside
                namespace BullyTracker.Common
                {
                    public class HashEncryption
                    {
                        //public string GenerateHashvalue(string thisPassword)
                        //{
                        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                        //    byte[] tmpSource;
                        //    byte[] tmpHash;
                        //    tmpSource = ASCIIEncoding.ASCII.GetBytes(thisPassword); // Turn password into byte array
                        //    tmpHash = md5.ComputeHash(tmpSource);
                        //    StringBuilder sOutput = new StringBuilder(tmpHash.Length);
                        //    for (int i = 0; i < tmpHash.Length; i++)
                        //    {
                        //        sOutput.Append(tmpHash[i].ToString("X2"));  // X2 formats to hexadecimal
                        //    }
                        //    return sOutput.ToString();
                        //}
                        //public Boolean VerifyHashPassword(string thisPassword, string thisHash)
                        //{
                        //    Boolean IsValid = false;
                        //    string tmpHash = GenerateHashvalue(thisPassword); // Call the routine on user input
                        //    if (tmpHash == thisHash) IsValid = true;  // Compare to previously generated hash
                        //    return IsValid;
                        //}
                        public string GenerateHashvalue(string toEncrypt, bool useHashing)
                        {
                            byte[] keyArray;
                            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                            // Get the key from config file
                            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                            //System.Windows.Forms.MessageBox.Show(key);
                            if (useHashing)
                            {
                                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                                hashmd5.Clear();
                            }
                            else
                                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                            tdes.Key = keyArray;
                            tdes.Mode = CipherMode.ECB;
                            tdes.Padding = PaddingMode.PKCS7;
                            ICryptoTransform cTransform = tdes.CreateEncryptor();
                            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                            tdes.Clear();
                            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                        }
                        /// <summary>
                        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
                        /// </summary>
                        /// <param name="cipherString">encrypted string</param>
                        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
                        /// <returns></returns>
                        public string Decrypt(string cipherString, bool useHashing)
                        {
                            byte[] keyArray;
                            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                            //Get your key from config file to open the lock!
                            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                            if (useHashing)
                            {
                                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                                hashmd5.Clear();
                            }
                            else
                                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                            tdes.Key = keyArray;
                            tdes.Mode = CipherMode.ECB;
                            tdes.Padding = PaddingMode.PKCS7;
                            ICryptoTransform cTransform = tdes.CreateDecryptor();
                            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                            tdes.Clear();
                            return UTF8Encoding.UTF8.GetString(resultArray);
                        }
                    }
                }
