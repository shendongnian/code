    List<Int32> numbering = new List<Int32>();
    
    Int32 lastNestingLevel = -1;
    
    foreach (String line in lines)
    {
        String[] parts = line.Split(new Char[] { ' ' }, 2);
    
        Int32 currentNestingLevel = parts[0].Count(c => c == '.');
    
        if (currentNestingLevel > lastNestingLevel)
        {
            // Start a new nesting level with number one.
            numbering.Add(1);
        }
        else if (currentNestingLevel == lastNestingLevel)
        {
             // Increment the number of the current nesting level.
            numbering[currentNestingLevel] += 1;        }
        else if (currentNestingLevel < lastNestingLevel)
        {
             // Remove the deepest nesting level...
            numbering.RemoveAt(numbering.Count - 1);
             // ...and increment the numbering of the current nesting level.
            numbering[currentNestingLevel] += 1;
        }
    
        lastNestingLevel = currentNestingLevel;
    
        String newNumbering = String.Join(".", numbering
            .Select(n => n.ToString())
            .ToArray());
    
        Console.WriteLine(newNumbering + " " + parts[1]);
    }
