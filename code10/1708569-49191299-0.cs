    public class Program
    {
        public static void Main(string[] args)
        {
        List<string> listLocationID = new List<string>();
        listLocationID.Add("one");
        listLocationID.Add("two");
        listLocationID.Add("three");
            
         String strSentence = string.Empty;
         for (int i = 0; i < listLocationID.Count; i++)
            {
             strSentence = strSentence + (listLocationID[i]);
            }
            Console.Write(strSentence);
        }
    }
