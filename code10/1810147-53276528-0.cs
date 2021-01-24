                var firstname = string.Empty;
                var lastname = string.Empty;
                var dt = DateTime.MinValue;
                do
                {
                    System.Console.Write("Give first name");
                     firstname = System.Console.ReadLine();
    
                } while (string.IsNullOrEmpty(firstname));
                do
                {
                    System.Console.Write("Give last name");
                     lastname = System.Console.ReadLine();
                } while (string.IsNullOrEmpty(lastname));
    
    
                do
                {
                    System.Console.Write("Give date of birth");
                     dt = DateTime.Parse(System.Console.ReadLine());
                } while (dt != DateTime.MinValue);
