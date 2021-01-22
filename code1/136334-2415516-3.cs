    List<ItemDoc> itemDocList = new List<ItemDoc>()
    {
        new ItemDoc() 
        {
             Details = new List<ItemDetailDoc>()
             {
                 new ItemDetailDoc()
                 {
                      Events = new List<EventDoc>()
                      {
                          new EventDoc()
                          {HasEAN=false},
                          new EventDoc()
                          {HasEAN=false}
                      }
                 },
                 new ItemDetailDoc()
                 {
                      Events = new List<EventDoc>()
                      {
                          new EventDoc()
                          {HasEAN=true},
                          new EventDoc()
                          {HasEAN=false}
                      }
                 }
             }
        },
        new ItemDoc() 
        {
             Details = new List<ItemDetailDoc>()
             {
                 new ItemDetailDoc()
                 {
                      Events = new List<EventDoc>()
                      {
                          new EventDoc()
                          {HasEAN=false},
                          new EventDoc()
                          {HasEAN=false}
                      }
                 },
                 new ItemDetailDoc()
                 {
                      Events = new List<EventDoc>()
                      {
                          new EventDoc()
                          {HasEAN=false},
                          new EventDoc()
                          {HasEAN=false}
                      }
                 }
             }
        }
    };
