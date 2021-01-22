    public IList BuildTree(IEnumerable<string> strings)
    {
      return
        from s in strings
        let split = s.Split("/")
        group s by s.Split("/")[0] into g  // Group by first component (before /)
        select new
        {
          Name = g.Key,
          Children = BuildTree(            // Recursively build children
            from s in grp
            where s.Length > g.Key.Length+1
            select s.Substring(g.Key.Length+1)) // Select remaining components
        };
    }
