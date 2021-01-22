      public SecureString getPassword()
            {
                SecureString pwd = new SecureString();
                while (true)
                {
                    ConsoleKeyInfo i = Console.ReadKey(true);
                    if (i.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (i.Key == ConsoleKey.Backspace)
                    {
                        if (pwd.Length > 0)
                        {
                            pwd.RemoveAt(pwd.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        pwd.AppendChar(i.KeyChar);
                        Console.Write("*");
                    }
                }
                return pwd;
            }
