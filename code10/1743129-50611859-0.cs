    public class Abbreviation
    {
        public int Pos { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            abbreviations.Add(new Abbreviation() { Pos = 29, ShortName = "exp.", LongName = "expression" });
            abbreviations.Add(new Abbreviation() { Pos = 39, ShortName = "para.", LongName = "paragraph" });
            abbreviations.Add(new Abbreviation() { Pos = 54, ShortName = "ans.", LongName = "answer" });
            string test = "What is exp.? This is a test exp. in a para. contains ans. for a question";
            string temp = "";
            int tempPos = 0;
            abbreviations.ForEach(x =>
            {
                if (!String.IsNullOrEmpty(test) && (test.Length >= x.Pos + x.ShortName.Length) && test.Substring(x.Pos, x.ShortName.Length) == x.ShortName)
                {
                    temp += test.Substring(tempPos, x.Pos) + x.LongName;
                }
                tempPos = x.Pos + x.ShortName.Length;
            });
            Console.WriteLine(temp);
        }
    }
