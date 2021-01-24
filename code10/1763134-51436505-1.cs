     //This solution does not give the entire constant structure as name and FD[0] can be changed
            static readonly FD[] models= new[]
              {
                  new FD(){name="one" , CE= new double[]{1.0,2.0 } },
                  new FD(){name="two", CE= new double[]{3.0,4.0}}
               
              };
    
            //Here name can not be changed but models2[0] can be
            static readonly FD2[] models2 = new[]
            {
                new FD2("one",new double[]{1.0,2.0 }),
                new FD2("two", new double[]{3.0,4.0 })
            };
    
            //This is the best solution
            static readonly IReadOnlyList<FD2> models3 = new ReadOnlyCollection<FD2>(new[] {
                new FD2("one",new double[]{1.0,2.0 }),
                new FD2("two", new double[]{3.0,4.0 })
            }
            );
    
            //This is also a good solution but models4[0].CE[0] can be changed
            static readonly ReadOnlyCollection<FD> models4 = new ReadOnlyCollection<FD>(new[]
            {
                 new FD(){name="one" , CE= new double[]{1.0,2.0 }},
                 new FD(){name="two", CE= new double[]{3.0,4.0}}
            }); 
