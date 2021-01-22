    var entities = new[] 
    {
        new Entity
        {
            Date = new DateTime(2009, 12, 10)
        },
        new Entity
        {
            Date = new DateTime(2009, 12, 11)
        },
        new Entity
        {
            Date = new DateTime(2009, 12, 9)
        }
    };
    Array.Sort(entities, (e1, e2) => e1.Date.CompareTo(e2.Date));
