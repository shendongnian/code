    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                ICollection<VanillaOption> src = new List<VanillaOption>();
            ICollection<Derivative> dst = new List<Derivative>();
             copyAssets(src, dst);
            }
    
            public static void copyAssets<T,G>(ICollection<T> src, ICollection<G> dst) where T : G {
                foreach(T asset in src) 
                    dst.Add(asset);
            }
        }
        public class Asset {}
        public class Derivative : Asset {}
        public class VanillaOption : Derivative {}
    }
