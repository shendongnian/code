    static void Main(string[] args)
    {
       Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
       Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
       Console.WriteLine(Resources.Hello);
    }
