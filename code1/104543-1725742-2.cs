    //Program Output: 
    List1:
    206aa77c-8259-428b-a4a0-0e005d8b016c
    64f71cc9-596d-4cb8-9eb3-35da3b96f583
    
    List2:
    10382452-a7fe-4307-ae4c-41580dc69146
    97f3f3f6-6e64-4109-9737-cb72280bc112
    64f71cc9-596d-4cb8-9eb3-35da3b96f583
    
    Matches:
    64f71cc9-596d-4cb8-9eb3-35da3b96f583
    Press any key to continue . . .
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                //test initialization
                List<ClassTypeA> list1 = new List<ClassTypeA>();
                List<ClassTypeB> list2 = new List<ClassTypeB>();
    
                ClassTypeA citem = new ClassTypeA();
                ClassTypeB citem2 = new ClassTypeB();
                citem2.ID = citem.ID;
    
                list1.Add(new ClassTypeA());
                list1.Add(citem);
                list2.Add(new ClassTypeB());
                list2.Add(new ClassTypeB());
                list2.Add(citem2);
    
    
                //new common list. 
                List<ICommonTypeMakeUpYourOwnName> common_list = 
                            new List<ICommonTypeMakeUpYourOwnName>();
                
                //in english,  give me everything in list 1 
                //and cast it to the interface
                common_list.AddRange(
                  list1.ConvertAll<ICommonTypeMakeUpYourOwnName>(delegate(
                      ClassTypeA x) { return (ICommonTypeMakeUpYourOwnName)x; }));
    
                //in english, give me all the items in the 
                //common list that don't exist in list2 and remove them. 
                common_list.RemoveAll(delegate(ICommonTypeMakeUpYourOwnName x) 
                   { return list2.Find(delegate(ClassTypeB y) 
                          {return y.ID == x.ID;}) == null; });
    
                //show list1 
                Console.WriteLine("List1:");
                foreach (ClassTypeA item in list1)
                {
                    Console.WriteLine(item.ID);
                }
                //show list2
                Console.WriteLine("\nList2:");
                foreach (ClassTypeB item in list2)
                {
                    Console.WriteLine(item.ID);
                }
    
                //show the common items
                Console.WriteLine("\nMatches:");
                foreach (ICommonTypeMakeUpYourOwnName item in common_list)
                {
                    Console.WriteLine(item.ID);
                }
            }
    
        }
    
        interface ICommonTypeMakeUpYourOwnName
        {
            Guid ID { get; set; }
        }
    
        class ClassTypeA : ICommonTypeMakeUpYourOwnName
        {
            Guid _ID;
            public Guid ID {get { return _ID; } set { _ID = value;}}
            int _Stuff1;
            public int Stuff1 {get { return _Stuff1; } set { _Stuff1 = value;}}
            string _Stuff2;
            public string Stuff2 {get { return _Stuff2; } set { _Stuff2 = value;}}
    
            public ClassTypeA()
            {
                this.ID = Guid.NewGuid();
            }
        }
    
        class ClassTypeB : ICommonTypeMakeUpYourOwnName
        {
            Guid _ID;
            public Guid ID {get { return _ID; } set { _ID = value;}}
            int _Stuff3;
            public int Stuff3 {get { return _Stuff3; } set { _Stuff3 = value;}}
            string _Stuff4;
            public string Stuff4 {get { return _Stuff4; } set { _Stuff4 = value;}}
    
            public ClassTypeB()
            {
                this.ID = Guid.NewGuid();
            }
    
        }
    }
    
