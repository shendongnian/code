    class Program
        {
            static void Main(string[] args)
            {
                Shape[] a = new Shape[2] { new Square(1), new Triangle() };
             
                FileStream fS = new FileStream("C:\\shape.xml",FileMode.OpenOrCreate);
                
                //this could be much cleaner
                Type[] t = { a[1].GetType(), a[0].GetType() };
    
    
                XmlSerializer xS = new XmlSerializer(a.GetType(),t);
                Console.WriteLine("writing");
                try
                {
                    xS.Serialize(fS, a);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.ToString());
                    Console.ReadKey();
                }
                fS.Close();
                Console.WriteLine("Fin");
            }
        }
    
    namespace XMLInheritTests
    {
        [XmlInclude(typeof(Square))]
        [XmlInclude(typeof(Triangle))]
        public abstract class Shape
        {
            public Shape() { }
            public int area;
            public int edges;
        }
    }
