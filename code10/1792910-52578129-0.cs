    string filmName = string.empty;
    if (filmNum == 1) ;
            {
                filmName = "Teenage Horror Film";
            }
            if (filmNum == 2) ;
            {
                filmName = "How I Live Now";
            }
    
            switch (filmNum)
            {
                case 1: case 2:
                    if (Age >= 15)
                    {
                        Console.WriteLine("What date do you want to watch the film? (Format : dd/mm/yyyy) :");
                        DateTime dateChoice = DateTime.Parse(Console.ReadLine());
                        DateTime now = DateTime.Now;
                        DateTime limit = now.AddDays(7);
                        if (dateChoice >= now && dateChoice <= limit)
                        {
                            Console.WriteLine("--------------------");
                            Console.WriteLine("Aquinas Multiplex");
                            Console.WriteLine("Film : {0}", filmName);
                            Console.WriteLine("Date : {0}", dateChoice);
                            Console.WriteLine("--------------------");
                        }
                        else
                        {
                            Console.WriteLine("Access denied - date is invalid");
                        }
                    }
    
                    while (Age < 15)
                    {
                        Console.WriteLine("Access denied - You are too young");
                    }
                    break;
    
            }
        }
    }
