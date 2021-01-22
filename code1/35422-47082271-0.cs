    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Enudemo
    {
    
        class Person
        {
            string name = "";
            int roll;
    
            public Person(string name, int roll)
            {
                this.name = name;
                this.roll = roll;
            }
    
            public override string ToString()
            {
                return string.Format("Name : " + name + "\t Roll : " + roll);
            }
    
        }
    
    
        class Demo : IEnumerable
        {
            ArrayList list1 = new ArrayList();
    
            public Demo()
            {
                list1.Add(new Person("Shahriar", 332));
                list1.Add(new Person("Sujon", 333));
                list1.Add(new Person("Sumona", 334));
                list1.Add(new Person("Shakil", 335));
                list1.Add(new Person("Shruti", 336));
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
               return list1.GetEnumerator();
            }
        }
    
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Demo d = new Demo();  // Notice here. it is simple object but for 
                                    //IEnumerator you can get the collection data
    
                foreach (Person X in d)
                {
                    Console.WriteLine(X);
                }
    
                Console.ReadKey();
            }
        }
    }
    /*
    Output : 
    
    Name : Shahriar  Roll : 332
    Name : Sujon     Roll : 333
    Name : Sumona    Roll : 334
    Name : Shakil    Roll : 335
    Name : Shruti    Roll : 336
      */
