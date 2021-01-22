    class Program
    {
        static void Main(string[] args)
        {
            var newInfo = new List<MyClass>();
            var myDict = new Dictionary<string, MyClass>();
            foreach (var item in newInfo)
            {
                MyClass temp;
                if (!myDict.TryGetValue(item.Name, out temp))
                {
                    temp = new MyClass() { Name = item.Name };
                    myDict.Add(temp.Name,temp);
                }
                temp.NewInfo += 1;
            }
        }
    }
    class MyClass
    {
        public string Name;
        public int NewInfo;
    }
