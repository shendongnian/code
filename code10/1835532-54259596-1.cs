        public static string GetValue(string myString,int position)
        {
            return myString.Split(',')[position - 1];
        }
        static void Main(string[] args)
        {
            string myItem = "22";
            Console.WriteLine(GetValue("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27", 22));
            Console.ReadLine();  
        }  
