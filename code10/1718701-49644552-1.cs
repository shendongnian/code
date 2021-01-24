     bool valid = false;
                decimal HOURS = 0;
                while (!valid)
                {
                    Console.WriteLine("Enter hours of parking: ");
                 bool parse =  decimal.TryParse(Console.ReadLine(),out HOURS);
                    if (!parse)
                    {
                        Console.WriteLine("Not a number.");
                        continue;
                    }
    
                    if(HOURS > 0 && HOURS <= 24)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Hours must me greather then 0 and less or equal to 24");
                    }
                }
