    public class Stuff
    {
        public int A { get; set; }
        public float B { get; set; }
        public int C { get; set; }
        public float D { get; set; }
        public int E { get; set; }
        public List<float> GetAllFloats()
        {
            var floatFields = GetType().GetProperties()
              .Where(p => p.PropertyType == typeof(float));
            return floatFields.Select(p => (float)p.GetValue(this)).ToList();
        }
    }
    class Program
    {   
        static void Main()
        {
            Stuff obj = new Stuff() { A = 1, B = 2, C = 3, D = 4, E = 5 };
            obj.GetAllFloats().ForEach(f => Console.WriteLine(f));
            Console.ReadKey();
        }
    }
