       public interface IShared
        {
            int Prop1 {get; set;}
            string Prop2 {get; set;}
        }
        public class A : IShared
        {
            public int Prop1 {get; set;}
            public string Prop2 {get; set;}
        }
        public class B : IShared
        {
            public int Prop1 {get; set;}
            public string Prop2 {get; set;}
        }
        static void Main(string[] args)
        {
            A A = new A(){ Prop1 = 1, Prop2 = "2" };
            B B = new B();
            var properties = typeof(IShared).GetProperties();
            foreach (var prop in properties)
            {
                object currentValue = prop.GetValue(A, null);
                prop.SetValue(B, currentValue, null);
            }
            Console.WriteLine("B = " + B.Prop1 + " " + B.Prop2);
            Console.ReadKey();
