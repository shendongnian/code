    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                List<MyObject> colection =new List<MyObject>{ new MyObject{ id=1, Name="obj1" }, 
                                                        new MyObject{ id=2, Name="obj2"} };
    
                foreach (MyObject b in colection)
                {
                 // b += 3;     //Doesn't work
                    b.Add(3);   //Works
                }
            }
    
            class MyObject
            {
                public static MyObject operator +(MyObject b1, int b2)
                {
                    return new MyObject { id = b1.id + b2, Name = b1.Name };
                }
    
              public void Add(int b2)
              {
                  this.id += b2;
              }
                public string Name;
                public int id;
            }
        }
    }
