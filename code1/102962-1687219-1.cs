    var haystack = new Pool().Constituents;
    var indexedhaystack = haystack.Select((item, index)=> new {
        item, index
    });
    var pool = new Pool()
    {
        Constituents = from l in indexedhaystack
                       select new Constituent()
                       {
                            //your stuff here
                       }
    };
