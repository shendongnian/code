    var someList = new List<SomeClass>()
                      {
                         new SomeClass()
                            {
                               Name = "asd",
                               Car = "sdfsdf"
                            },
                         new SomeClass()
                            {
                               Name = "dfgfdg",
                               Car = "dfgdf"
                            }
                      };
    
    
    var SomeClass = CreateType(someList);
