    class Program
    {
        static void Main(string[] args)
        {
            object[,] OneObject = new object[1,3]{ {"C Sharp",4,3.5 }};
            List<object> MyList = new List<object>();
            MyList.Add(OneObject);
            object[,] addObject = new object[1,3]{{"Java",1,1.1}};
            MyList.Add(addObject);
            foreach(object SingleObject in MyList)
            {
                object[,] MyObject = (object[,])SingleObject;
                Console.WriteLine("{0},{1},{2}", MyObject[0, 0], MyObject[0, 1], MyObject[0, 2]);
            }  
            
            Console.Read();
        }
    }
