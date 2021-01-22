    // This is the Callback handler - after "Binding" this is called
            public bool MySSLHandler(Syscert.X509Certificate certificate, int[] certificateErrors)
            {
    
                X509Store store = null;
                X509Stores stores = X509StoreManager.LocalMachine;
                store = stores.TrustedRoot;
    
                //Import the details of the certificate from the server.
    
                X509Certificate x509 = null;
                X509CertificateCollection coll = new X509CertificateCollection();
                byte[] data = certificate.GetRawCertData();
                if (data != null)
                    x509 = new X509Certificate(data);
    
                //List the details of the Server
    
                //if (bindCount == 1)
                //{
    
                Response.Write("<b><u>CERTIFICATE DETAILS:</b></u> <br>");
                Response.Write("  Self Signed = " + x509.IsSelfSigned + "  X.509  version=" + x509.Version + "<br>");
                Response.Write("  Serial Number: " + CryptoConvert.ToHex(x509.SerialNumber) + "<br>");
                Response.Write("  Issuer Name:   " + x509.IssuerName.ToString() + "<br>");
                Response.Write("  Subject Name:  " + x509.SubjectName.ToString() + "<br>");
                Response.Write("  Valid From:    " + x509.ValidFrom.ToString() + "<br>");
                Response.Write("  Valid Until:   " + x509.ValidUntil.ToString() + "<br>");
                Response.Write("  Unique Hash:   " + CryptoConvert.ToHex(x509.Hash).ToString() + "<br>");
                // }
    
                bHowToProceed = true;
                if (bHowToProceed == true)
                {
                    //Add the certificate to the store. This is \Documents and Settings\program data\.mono. . .
                    if (x509 != null)
                        coll.Add(x509);
                    store.Import(x509);
                    if (bindCount == 1)
                        removeFlag = true;
                }
    
                if (bHowToProceed == false)
                {
                    //Remove the certificate added from the store.
    
                    if (removeFlag == true && bindCount > 1)
                    {
                        foreach (X509Certificate xt509 in store.Certificates)
                        {
                            if (CryptoConvert.ToHex(xt509.Hash) == CryptoConvert.ToHex(x509.Hash))
                            {
                                store.Remove(x509);
                            }
                        }
                    }
                    Response.Write("SSL Bind Failed.");
                }
                return bHowToProceed;
            }
