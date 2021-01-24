              do
                {
                    System.Console.Write("Give first name");
                    String firstname = System.Console.ReadLine();
                    if (firstname == "")
                    {
                        break;
                    }
                    System.Console.Write("Give last name");
                    String lastname = System.Console.ReadLine();
                    if (lastname == "")
                    {
                        break;
                    }
                    System.Console.Write("Give date of birth");
                     DateTime dt = DateTime.Parse(System.Console.ReadLine());
                    if (dt.ToString()=="")
                    {
                        break;
                    }
    
                } while (Console.ReadLine()!=null);
