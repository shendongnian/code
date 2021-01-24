            bool value = true;
            while (value==true)
            {
                System.Console.Write("Give first name");
                String firstname = System.Console.ReadLine();
                if (firstname == "")
                {
                    value = false;
                    break;
                }
                System.Console.Write("Give last name");
                String lastname = System.Console.ReadLine();
                if (lastname == "")
                {
                    value = false;
                    break;
                }
                System.Console.Write("Give date of birth");
                 DateTime dt = DateTime.Parse(System.Console.ReadLine());
                if (dt.ToString()=="")
                {
                    value = false;
                    break;
                }
            }
