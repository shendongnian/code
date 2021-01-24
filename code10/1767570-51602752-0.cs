            string a = "cat";
            string b = "dog";
            string c = "cat";
            string d = "horse";
            var list = new List<string>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            var result = GetCount(list);
            Console.WriteLine(result);
            Console.ReadLine();
     static string GetCount(List<string> obj)
            {
                string result = string.Empty;
                int cat = 0;
                int dog = 0;
                int horse = 0;
    
                foreach (var item in obj)
                {
                    switch (item)
                    {
                        case "dog":
                            dog++;
                            break;
                        case "cat":
                            cat++;
                            break;
                        case "horse":
                            horse++;
                            break;
                    }
                }
    
                result = "cat = " + cat.ToString() + " dog = " + dog.ToString() + " horse = " + horse.ToString();
    
                return result;
            }
