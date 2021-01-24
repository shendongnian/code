     static void Main(string[] args)
        {
    
            List<List<string>> dynamicList = new List<List<string>>();
            List<string> param1List = new List<string>();
            List<string> param2List = new List<string>();
            List<string> param3List = new List<string>();
            List<string> param4List = new List<string>();
    
            param1List.Add("Apple");
            param1List.Add("Orange");
            param2List.Add("Broccoli");
            param2List.Add("Carrots");
            param2List.Add("Peas");
            param2List.Add("Green Beans");
    
            param3List.Add("Ice cream");
            param3List.Add("Pie");
    
            param4List.Add("Thank");
            param4List.Add("You");
    
    
            dynamicList.Add(param1List);
            dynamicList.Add(param2List);
            dynamicList.Add(param3List);
            dynamicList.Add(param4List);
    
    
            List<string> result = null;
            dynamicList.ForEach(x => BuildString(ref result, x));
            result.ForEach(i => Console.WriteLine(i));
            Console.ReadLine();
        }
    
        static void BuildString(ref List<string> param1List, List<string> param2List)
        {
            if (param1List == null)
            {
                param1List = param2List;
                return;
            }
    
            List<string> result = new List<string>();
            param1List.ForEach(x => param2List.ForEach(y => result.Add(String.Format("{0} - {1}", x, y))));
            param1List = result;
            
        }
