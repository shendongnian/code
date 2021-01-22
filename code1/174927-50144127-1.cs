     using (var context = new YourDatabaseContext())
            {       
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var sql = String.Format("OPEN SYMMETRIC KEY {0} DECRYPTION BY CERTIFICATE {1}", KeyName, CertName);
                        context.Database.ExecuteSqlCommand(sql);
                        sql = String.Format("SELECT CONVERT(varchar, DecryptByKey(Encrypted_Password)) FROM Application_Credentials WHERE User_Name = '{0}'", UserNameToDecryptCredsFor);
                        var result = context.Database.SqlQuery<string>(sql).FirstOrDefault();
                        sql = String.Format("CLOSE SYMMETRIC KEY {0}", KeyName);
                        context.Database.ExecuteSqlCommand(sql);
                    }
                    catch (Exception exp)
                    {
                        var x = exp.ToString(); //do something with exception
                    }
                }
            }
