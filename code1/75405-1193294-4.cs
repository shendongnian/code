                const string file = @"\\machine\test\file.txt";
                
                using (UserImpersonation user = new UserImpersonation("user", "domain", "password"))
                {
                    if (user.ImpersonateValidUser())
                    {
                        StreamReader reader = new StreamReader(file);
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                    }
                }
