    namespace Swap
    {
    public class Class1
    {
        public SortedDictionary<string, string> names;
        public void BeforeSwaping()
        {
            Console.WriteLine("Before Swapping: ");
            Console.WriteLine();
            names = new SortedDictionary<string, string>();
            names.Add("Sonoo", "srinath");
            names.Add("Perer", "mahesh");
            names.Add("James", "ramesh");
            names.Add("Ratan", "badri");
            names.Add("Irfan", "suresh");
            names.Add("sravan", "current");
            foreach (KeyValuePair<string, string> item in names)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
        public void AfterSwaping()
        {
            Console.WriteLine("After Swapping: ");
            Console.WriteLine();
            var key = names.Keys;
            var val = names.Values;
            string[] arrayKey = new string[key.Count];
            string[] arrayVal = new string[val.Count];
            int i = 0;
            foreach (string s in key)
            {
                arrayKey[i++] = s;
            }
            int j = 0;
            foreach (string s in val)
            {
                arrayVal[j++] = s;
            }
            names.Clear();
            //Console.WriteLine(arrayVal[0] + " " + arrayKey[0]);
            for (int k = 0; k < (arrayKey.Length + arrayVal.Length) / 2; k++)
            {
                names.Add(arrayVal[k], arrayKey[k]);
            }
            foreach (KeyValuePair<string, string> s in names)
            {
                Console.WriteLine("key:"+s.Key + ", "+"value:" + s.Value);
            }
        }
        public static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.BeforeSwaping();
            c.AfterSwaping();
            Console.ReadKey();
        }
      }
    }
