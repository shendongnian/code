    bool valid = false;
            int hours = 0;
            while (!valid)
            {
                Console.WriteLine("Enter Number Of Hours Parked");
                hours = int.Parse(Console.ReadLine());
             
                if(hours > 0 && hours <= 24)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Hours must me greather then 0 and less or equal to 24");
                }
            }
