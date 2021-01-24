    static void Main(string[] args)
    {
    	string hex = "#FFFFFF";
    	Color color = System.Drawing.ColorTranslator.FromHtml(hex);
    	Console.WriteLine("R: {0} G: {1} B: {2}", color.R, color.G, color.B);
    	Console.ReadKey(true);
    }
