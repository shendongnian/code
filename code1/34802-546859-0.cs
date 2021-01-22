    // assume List <List<Class>> L = new List<List<Class>>(); from question
    HashSet<int> lineNumbersTaken = new HashSet();
    var result = L.Where(lOuter => 
    {
        var innerResult = lOuter.Where(c => 
        {
            if (!lineNumbersTaken.Contains(c.IDLinea))
            {
                lineNumbersTaken.Add(c.IDLinea);
                return true;
            }
            return false;
        });
        return innerResult.Count() != 0;
    });
