    foreach (var signerInfo in signedCms.SignerInfos)
                {
                    foreach (var unsignedAttribute in signerInfo.UnsignedAttributes)
                    {
                        if (unsignedAttribute.Oid.Value == WinCrypt.szOID_RSA_counterSign)
                        {
                            foreach (var counterSignInfo in signerInfo.CounterSignerInfos)
                            {
                                foreach (var signedAttribute in counterSignInfo.SignedAttributes)
                                {
                                    if (signedAttribute.Oid.Value == WinCrypt.szOID_RSA_signingTime)
                                    {                                        
                                        System.Runtime.InteropServices.ComTypes.FILETIME fileTime = new System.Runtime.InteropServices.ComTypes.FILETIME();
                                        int fileTimeSize = Marshal.SizeOf(fileTime);
                                        IntPtr fileTimePtr = Marshal.AllocCoTaskMem(fileTimeSize);
                                        Marshal.StructureToPtr(fileTime, fileTimePtr, true);
                                        byte[] buffdata = new byte[fileTimeSize];
                                        Marshal.Copy(fileTimePtr, buffdata, 0, fileTimeSize);
                                        uint buffSize = (uint)buffdata.Length;
                                        uint encoding = WinCrypt.X509_ASN_ENCODING | WinCrypt.PKCS_7_ASN_ENCODING;
                                        UIntPtr rsaSigningTime = (UIntPtr)(uint)Marshal.StringToHGlobalAnsi(WinCrypt.szOID_RSA_signingTime);
                                        byte[] pbData = signerInfo.CounterSignerInfos[0].SignedAttributes[1].Values[0].RawData;                                        
                                        uint ucbData = (uint)pbData.Length;
                                        bool workie = WinCrypt.CryptDecodeObject(encoding, rsaSigningTime.ToUInt32(), pbData, ucbData, 0, buffdata, ref buffSize);
                                        if (workie)
                                        {
                                            IntPtr fileTimePtr2 = Marshal.AllocCoTaskMem(buffdata.Length);
                                            Marshal.Copy(buffdata, 0, fileTimePtr2, buffdata.Length);
                                            System.Runtime.InteropServices.ComTypes.FILETIME fileTime2 = (System.Runtime.InteropServices.ComTypes.FILETIME)Marshal.PtrToStructure(fileTimePtr2, typeof(System.Runtime.InteropServices.ComTypes.FILETIME));
                                            
                                            long hFT2 = (((long)fileTime2.dwHighDateTime) << 32) + ((uint)fileTime2.dwLowDateTime);
                                            DateTime dte = DateTime.FromFileTime(hFT2);
                                            Console.WriteLine(dte.ToString());
                                        }
                                        else
                                        {
                                            throw new Win32Exception(Marshal.GetLastWin32Error());                                            
                                        }
                                    }    
                                }
                                
                            }                            
                         
                            return true;
                        }
                    }
                }
