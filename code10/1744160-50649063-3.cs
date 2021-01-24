            Sex real_sex = null;
            if (sex == "boy")
            {
                Console.WriteLine("You are a boy");
                real_sex = new Boy
                {
                    Firstname = "George",
                    Secondname = "Smith"
                };
            }
            else if (sex == "girl")
            {
                Console.WriteLine("You are a girl");
                real_sex = new Girl
                {
                    Firstname = "Charlotte",
                    Secondname = "Smith"
                };
            }
    
            real_sex.Characteristics()    
