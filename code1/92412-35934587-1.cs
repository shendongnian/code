    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1 {
    
    class Box
    {
        public int Id;
        public string Name;
        public Box(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    
    class BoxEq: IEqualityComparer<Box>
    {
        public Box Element;
    
        public bool Equals(Box element, Box representative)
        {
            bool found = element.Id == representative.Id;
            if (found)
            {
                Element = element;
            }
            return found;
        }
    
        public int GetHashCode(Box box)
        {
            return box.Id.GetHashCode();
        }
    }
    
    class Program
    {
        static void Main()
        {
            var boxEq = new BoxEq();
            var hashSet = new HashSet<Box>(boxEq);
            hashSet.Add(new Box(3, "Element 3"));
            var box5 = new Box(5, "Element 5");
            hashSet.Add(box5);
            var representative = new Box(5, "Representative 5");
            boxEq.Element = null;
            Console.WriteLine("Contains {0}: {1}", representative.Id, hashSet.Contains(representative));
            Console.WriteLine("Found id: {0}, name: {1}", boxEq.Element.Id, boxEq.Element.Name);
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }
    }
    
    } // namespace
