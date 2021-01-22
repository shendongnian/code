    class Program
    {
        const string FirstQuestion = "First question: ";
        const string SecondQuestion = "Another question: ";
        const string FinalQuestion = "Final question: ";
        static AutoResetEvent Done = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            const string TheProgram = @" ... ";
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(TheProgram);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            p.StartInfo = psi;
            Console.WriteLine("Executing " + TheProgram);
            p.Start();
            DoPromptsAsync(p);
            Done.WaitOne();
        }
        private static async Task DoPromptsAsync(Process p)
        {
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            string Question;
            Question = await sr.ReadLineAsync();
            if (Question != FirstQuestion)
                return;
            sw.WriteLine("First answer");
            Console.WriteLine(Question + "answered");
            Question = await sr.ReadLineAsync();
            if (Question != SecondQuestion)
                return;
            sw.WriteLine("Second answer");
            Console.WriteLine(Question + "answered");
            Question = await sr.ReadLineAsync();
            if (Question != FinalQuestion)
                return;
            sw.WriteLine("Final answer");
            Console.WriteLine(Question + "answered");
            Done.Set();
        }
    }
