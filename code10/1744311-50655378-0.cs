    public class Program
    {
        public static int arrLength = 0;
        public static string[] arr;
        public static Dictionary<char, int> dct = new Dictionary<char, int>();
        public static void Main(string[] args)
        {
            dct.Add('0', 0);
            dct.Add('1', 0);
            dct.Add('2', 0);
            dct.Add('3', 0);
            dct.Add('4', 0);
            dct.Add('5', 0);
            dct.Add('6', 0);
            dct.Add('7', 0);
            dct.Add('8', 0);
            dct.Add('9', 0);
            arr = Console.ReadLine().Split(' ');
            arrLength = arr.Length;
            foreach (string str in arr)
            {
                char[] ch = str.ToCharArray();
                ch = ch.Distinct<char>().ToArray();
                foreach (char c in ch)
                {
                    Exists(c, Array.IndexOf(arr, str));
                }
            }
            int val = dct.Values.Max();
            foreach(KeyValuePair<char,int> v in dct.Where(x => x.Value == val))
            {
                Console.WriteLine("Common digit {0} with frequency {1} ",v.Key,v.Value+1);
            }
            Console.ReadLine();
        }
        public static bool Exists(char c, int pos)
        {
            int count = 0;
            if (pos == arrLength - 1)
                return false;
            for (int i = pos; i < arrLength - 1; i++)
            {
                if (arr[i + 1].ToCharArray().Contains(c))
                {
                    count++;
                    if (count > dct[c])
                        dct[c] = count;
                }
                else
                    break;
            }
            return true;
        }
    }
