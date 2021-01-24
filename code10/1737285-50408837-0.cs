    public static void CommonMethod(dynamic collection)
    {
            Parent p = new Parent();
            Star s = new Star();
            s.Area = "infinite";
            s.Color = "red";
            foreach (var data in collection)
            {
                var properties = data.GetType().GetProperties();
                foreach (var p in properties)
                {
                    string propertytName = p.Name;
                    
                    var propertyValue = p.GetValue(data, null);
                    if (propertytName == "City" || propertytName == "Village")
                    {
                        List<string> sep = propertyValue.Split(',').ToList();
                        foreach (var b in sep)
                        {
                            TinyStar t = new TinyStar();
                            t.smallD = b;
                            s.Values.Add(t);
                        }
                        p.Curves.Add(s);
                    }
                } 
            }
        }
        static void Main(string[] args)
        {
            ComponentClass[] c Data from 3rd party;
            foreach (var data in c)
            {
                CommonMethod(data.classAObj);
                CommonMethod(data.classBObj);
            }
	}
