    List<Int32> numbering = new List<Int32>();
    
    Int32 lastNestingLevel = 0;
    
    foreach (String line in lines)
    {
        String[] parts = line.Split(new Char[] { ' ' }, 2);
    
        Int32 currentNestingLevel = parts[0].Count(c => c == '.') + 1;
    
        if (currentNestingLevel > lastNestingLevel)
        {
            numbering.Add(1);
        }
        else if (currentNestingLevel == lastNestingLevel)
        {
            numbering[currentNestingLevel - 1] += 1;
        }
        else if (currentNestingLevel < lastNestingLevel)
        {
            numbering.RemoveAt(numbering.Count - 1);
            numbering[currentNestingLevel - 1] += 1;
        }
    
        lastNestingLevel = currentNestingLevel;
    
        String newNumbering = String.Join(".", numbering
            .Select(n => n.ToString())
            .ToArray());
    
        Console.WriteLine(newNumbering + " " + parts[1]);
    }
