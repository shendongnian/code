    static void Main(string[] args)
            {          
    
                var inputText = "Testcase1";
                Console.WriteLine($"{inputText} =>{CalculateTotal(GetHashString(string.Concat(inputText,DateTime.Now.Date.ToString(),  DateTime.Now.TimeOfDay.ToString())).ToArray<char>())}");
                inputText = "Testcase2";
                Console.WriteLine($"{inputText} =>{CalculateTotal(GetHashString(string.Concat(inputText,DateTime.Now.Date.ToString(),  DateTime.Now.TimeOfDay.ToString())).ToArray<char>())}");
               
    
            }
            static string GetHashString(string inputText)
            {
                HashAlgorithm hash = new SHA256Managed();
                var bytes = new byte[inputText.Length];
                bytes = Encoding.ASCII.GetBytes(inputText);
                return Encoding.ASCII.GetString( hash.ComputeHash(bytes));
            }
            
            static long CalculateTotal(char [] items)
            {
    
                var i = Array.ConvertAll<char, long>(items, Convert.ToInt64);
                return i.Sum();             
            }
