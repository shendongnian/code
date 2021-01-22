    public class ConsoleSpinner
    {
        private int _counter;
        public void Turn(Color color, int max, string prefix = "Completed", string symbol = "■")
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"{prefix} {ComputeSpinner(_counter, max, symbol)}", color);
            _counter = _counter == max ? 0 : _counter + 1;
        }
        public string ComputeSpinner(int nmb, int max, string symbol)
        {
            var spinner = new StringBuilder();
            if (nmb == 0)
                return "\r ";
            spinner.Append($"[{nmb}%] [");
            for (var i = 0; i < max; i++)
            {
                spinner.Append(i < nmb ? symbol : " ");
            }
            spinner.Append("]");
            return spinner.ToString();
        }
    }
    public static void Main(string[] args)
        {
            var progressBar= new ConsoleSpinner();
            for (int i = 0; i < 1000; i++)
            {
                progressBar.Turn(Color.Aqua,100);
                Thread.Sleep(1000);
            }
        }
