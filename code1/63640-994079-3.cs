    void Main()
    {
        string xxx = "HELLO WORLD";
        int yyy = 42;
        DateTime zzz = DateTime.Now;
        DetectName(new { xxx });
        DetectName(new { yyy });
        DetectName(new { zzz });
        // or..
        // DetectName(new { xxx, yyy, zzz });
    }
    public void DetectName<T>(T test) where T : class
    {
        PropertyInfo[] piArray = typeof(T).GetProperties();
        foreach (PropertyInfo pi in piArray)
        {
            string name = pi.Name;
            object value = pi.GetValue(test, null);
            string output = "The Value: {0} was stored in the variable named: {1}.";
            Debug.WriteLine(string.Format(output, value, name));
        }
    }
