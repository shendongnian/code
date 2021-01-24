       case 3://linjär sökning av innehåll
                                Console.Write(" skriv in ett sökord");
                                string searchword = Console.ReadLine();
                                var lstElementsFound = stuff.Where(x => x.ToUpper() == searchword.ToUpper());
                                foreach (var item in stuff)
                                {
                                  Console.WriteLine("vi hittade" + item);
                                }
                                
                                break;
