    var orders = new System.Collections.Generic.List<Order>{
     new Order 
        {
        MaterialName = "MName", 
        MaterialType = 1,
        MaterialDescription = "Description",
        Roles = new Dictionary<string, string> 
            {
                {"Television", "ABCTV"},
                {"Radio", "ABCDEF RadioTV"},
            }
        },
         new Order 
        {
        MaterialName = "MName", 
        MaterialType = 1,
        MaterialDescription = "Description",
        Roles = new Dictionary<string, string> 
            {
                {"Television", "ABCTV"},
                {"Radio", "ABCDEF RadioTV"},
            }
        }
    };
