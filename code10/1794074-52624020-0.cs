    public static MyClass ConvertToMyClass(Dictionary<int, string> dictionary)
        {
            MyClass obj = new MyClass();
            foreach (var entry in dictionary)
            {
                obj.Add(entry.Key, entry.Value);
            }
            return obj;
        }
