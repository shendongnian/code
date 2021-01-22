    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    namespace ConsoleApplication1
    {
        public class IdValue<T>
        {
            public IdValue(int id, T value)
            {
                Id = id;
                Value = value;
            }
            public int Id { get; private set; }
            public T Value { get; private set; }
            public override string ToString()
            {
                return new JavaScriptSerializer().Serialize(this);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var idValue = new IdValue<string>(1, "Test");
                Console.WriteLine(idValue);
                Console.ReadKey();
            }
        }
    }
