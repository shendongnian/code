    ----------
    foreach (var item in multiplegrps)
                {
                    foreach (var yItem in item.YoungGroup)
                    {
                        if (item.YoungGroup.Count() > 0 && yItem.ElementAt(0) != null)
                        {
                            Console.WriteLine("Young : " + yItem.ElementAt(0).Name);
                        }
                    }
                    foreach (var aItem in item.AdultGroup)
                    {
                        if (item.AdultGroup.Count() > 0 &&aItem.ElementAt(0) != null)
                        {
                            Console.WriteLine("Adult : " + aItem.ElementAt(0).Name);
                        }
                    }
                    foreach (var sItem in item.SeniorGroup)
                    {
                        if (item.SeniorGroup.Count() > 0 &&sItem.ElementAt(0) != null)
                            {
                                Console.WriteLine("Senior : " + sItem.ElementAt(0).Name);
                            }
                    }
                }
