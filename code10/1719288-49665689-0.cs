            public void Test()
            {
                List<string> myList = new List<string>();
                using (var reader = new StreamReader(@"2018-03-16.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
    
                        var values = line.Split(';');
    
                        foreach (string item in values)
                        {
                            myList.Add(item);
                        }
                    }
                }
    
                this.FindItem(myList);
            }
    
            private void FindItem(List<string> myList)
            {
                // if you want the value
                var match = myList.FirstOrDefault(stringToCheck => stringToCheck.Equals("your item to check"));
    
                // if you just want to check if it exists
                var match2 = myList.Any(stringToCheck => stringToCheck.Equals("your item to check"));
            }
