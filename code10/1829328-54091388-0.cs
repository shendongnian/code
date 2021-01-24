    static void Main(string[] args)
        {
            int selectedID = (from x in StaticNames where x.Key.Contains(MyCategoryTypeName) select x.Value).FirstOrDefault();
            Console.WriteLine(selectedID);
            Console.ReadKey();
        }
        public static string MyCategoryTypeName = "الجيش";
        public static Dictionary<string, int> StaticNames = new Dictionary<string, int>()
            {
                {"الجيش" ,1},
                {"الأمن العام" ,2},
                {"أمن الدولة",3 },
                {"الجمارك" ,4 }
            };
