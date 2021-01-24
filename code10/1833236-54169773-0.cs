    class Program
    {
        public abstract class Astrodroid
        {
            public virtual string GetSound()
            {
                return "Beep beep";
            }
            public void MakeSound()
            {
                Console.WriteLine(this.GetSound());
                Console.ReadLine();
            }
        }
        public class MyClass:Astrodroid
        {
        }
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MakeSound();
        }
    }
