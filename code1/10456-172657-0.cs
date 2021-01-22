    namespace GenericsOne
    {
        using System;
    class Program
    {
        static void Main(string[] args)
        {
            Sample<int> one = new Sample<int>();
            one.AddFive(10);
            Sample<DateTime> two = new Sample<DateTime>();
            two.AddFive(new DateTime());
        }
    }
    }
    namespace GenericsOne
    {
        using System;
    public class Sample<T>
    {
        public int AddFive(T number)
        {
            int junk = 0;
            try
            {
                junk = Convert.ToInt32(number);
            }
            catch (Exception)
            {
                Console.WriteLine("Nope");
            }
            return junk + 5;
        }
    }
    }
