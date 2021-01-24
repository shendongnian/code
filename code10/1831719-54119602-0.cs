    foreach (var file in Directory.GetFiles(yourFolder, "*.cer"))
            {
                var mCert = X509Certificate2.Import(file);
                string email1 = mCert.GetNameInfo(X509NameType.SimpleName, false);
                string stringAfterChar = email1.Substring(email1.IndexOf("-") + 1);
                string name = mCert.GetNameInfo(X509NameType.SimpleName, false);
                string[] splitString = name.Split('-');
    
                string namewithoutemail = splitString[0].Trim();
    
                dt.Rows.Add(namewithoutemail , stringAfterChar,  mCert.NotBefore, mCert.GetExpirationDateString() , mCert.Thumbprint);
            }
