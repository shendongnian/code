    Dictionary<Int32, Int32> numbering = new Dictionary<Int32, Int32>();
    
    Int32 lastNestingLevel = -1;
    
    foreach (String line in lines)
    {
        String[] parts = line.Split(new Char[] { ' ' }, 2);
    
        Int32 currentNestingLevel = parts[0].Count(c => c == '.');
    
        if (currentNestingLevel > lastNestingLevel)
        {
            numbering[currentNestingLevel] = 1;
        }
        else
        {
            numbering[currentNestingLevel] += 1;
        }
    
        lastNestingLevel = currentNestingLevel;
    
        String newNumbering = String.Join(".", numbering
            .Where(n => n.Key <= currentNestingLevel)
            .OrderBy(n => n.Key)
            .Select(n => n.Value.ToString())
            .ToArray());
    
        Console.WriteLine(newNumbering + " " + parts[1]);
    }
