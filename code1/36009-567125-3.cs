    public class Program
    {
        static void Main(string[] args)
        {
            List<string> MyList = new List<string>();
            MyList.Add("smtp:user@domain.com");
            MyList.Add("smtp:user@otherdomain.com");
            MyList.Add("SMTP:user@anotherdomain.com");
            MyList.Sort(new MyStringComparer());
            
            foreach (string s in MyList)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
