    //Inside the Person class:
    public override string ToString()
    {
        List<String> propValues = new List<String>();
        // Get the type.
        Type t = this.GetType();
        // Cycle through the properties.
        foreach (PropertyInfo p in t.GetProperties())
        {
            propValues.add("{0}:={1}", p.Name, p.GetValue(o, null));
        }
        return String.Join(",". propValues.ToArray())
    }
    using (System.IO.TextWriter tw = new System.IO.StreamWriter("output.txt"))
    {
        tw.WriteLine(person.ToString());
    }
