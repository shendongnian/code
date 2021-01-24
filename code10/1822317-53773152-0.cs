    double Total = 0.00; 
            string destination = Console.ReadLine();
            int Destination = Convert.ToInt16(destination);
            switch (Destination)
            {
                case 1:
                    {
                        Console.WriteLine("you have selected Barbados! Heres the following excursions you can do!");
                        Console.WriteLine("_________________________!Excursions!_________________________________");
                        Console.WriteLine(" ");
                        Console.WriteLine("Snorkeling in Barbados bay: $199.99 Per Person");
                        Console.WriteLine("Press 1");
                        Console.WriteLine("Barbados Tour Bus Adventure: $59.99 Per Person");
                        Console.WriteLine("Press 2");
                        Console.WriteLine("Barbados Shopping Extravanga: $199.99 Per Person");
                        Console.WriteLine("Press 3");
                        Console.WriteLine("_________________________!Excursions!_________________________________");
                        Console.WriteLine(" ");
                        Console.WriteLine("What is your choice?");
                        string barbadosanswer = Console.ReadLine();
                        int barbadosAnswer = Convert.ToInt32(barbadosanswer);
                        switch(barbadosAnswer)
                        {
                            case 1:
                                Total += 199.99;
                                Console.WriteLine("You have selected Snorkeling in Barbados bay! Your total is currently " + Total);
                            break;
                        }
