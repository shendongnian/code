    static void Main(string[] args)
        {            
            var Lines = System.IO.File.ReadAllLines("input.txt");
            var Result = new StringBuilder();
            var SB = new StringBuilder();
            for (var i = 0; i < Lines.Length; i++)
            {
                SB.Append(Lines[i]);
                if ((i+1) % 3 == 0)
                {
                    Result.Append($"{SB.ToString()}{Environment.NewLine}");
                    SB.Clear();
                }
            }
            System.IO.File.WriteAllText("output.txt", Result.ToString());
            
        }
