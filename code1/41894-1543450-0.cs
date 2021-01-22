                string[] years = Directory.GetDirectories(ROOT);
                foreach (var year in years)
                {
                    DirectoryInfo info = new DirectoryInfo(year);
                    Console.WriteLine(info.Name);
                    Console.WriteLine(year);
                    //Month directories
                    string[] months = Directory.GetDirectories(year);
                    foreach (var month in months)
                    {
                        Console.WriteLine(month);
                        //Day directories
                        string[] days = Directory.GetDirectories(month);
                        foreach (var day in days)
                        {
                            //checkes the files in the days
                            Console.WriteLine(day);
                            string[] files = Directory.GetFiles(day);
                            foreach (var file in files)
                            {
                                Console.WriteLine(file);                               
                            }
                        }
                    }
                }
