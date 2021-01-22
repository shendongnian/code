    var props = from b in info.GetCustomAttributes(typeof(BugFixAttribute), false)
                from p in b.GetType().GetProperties()
                select new { 
                       Name = p.Name,
                       Value = p.GetValue(p.GetValue(b, null))
                       };
    foreach(var prop in props)
    {
        Debug.WriteLine(string.Format("{0}: {1}", prop.Name, prop.Value));
    }
