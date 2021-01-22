    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "abcefgh";
            var astr = new Permutation().GenerateFor(str);
            Console.WriteLine(astr.Length);
            foreach(var a in astr)
            {
                Console.WriteLine(a);
            }
            //a.ForEach(Console.WriteLine);
        }
    }
    
    class Permutation
    {
        public string[] GenerateFor(string s)
        {  
            
            if(s.Length == 1)
            {
               
                return new []{s}; 
            }
            
            else if(s.Length == 2)
            {
               
                return new []{s[1].ToString()+s[0].ToString(),s[0].ToString()+s[1].ToString()};
                
            }
            
            var comb = new List<string>();
            
            foreach(var c in s)
            {
                
                string cStr = c.ToString();
                
                var sToProcess = s.Replace(cStr,"");
                if (!string.IsNullOrEmpty(sToProcess) && sToProcess.Length>0)
                {
                    var conCatStr = GenerateFor(sToProcess);
                    
                    
                    
                    foreach(var a in conCatStr)
                    {
                        comb.Add(c.ToString()+a);
                    }
                        
                    
                }
            }
            return comb.ToArray();
            
        }
    }
