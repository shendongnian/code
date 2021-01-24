     static void Main(string[] args)
            {
    
                List<string> param1List = new List<string>();
                List<string> param2List = new List<string>();
                List<string> param3List = new List<string>();
    
                param1List.Add("Apple");
                param1List.Add("Orange");
                param2List.Add("Broccoli");
                param2List.Add("Carrots");
                param2List.Add("Peas");
                param2List.Add("Green Beans");
    
                param3List.Add("Ice cream");
                param3List.Add("Pie");
    
                var result = new List<string>();
                param1List.ForEach(x => param2List.ForEach(y => param3List.ForEach(z => result.Add(String.Format("{0} - {1} - {2}", x, y, z)))));
                result.ForEach(i => Console.WriteLine(i));
                Console.ReadLine();
            }
