    public class BothCaseConsole : IConsole
    {
        private readonly LowerCaseConsole lcc = new LowerCaseConsole();
        private readonly UpperCaseConsole ucc = new UpperCaseConsole();
        public void WriteLine(string text)
        {
            lcc.WriteLine(text);
            ucc.WriteLine(text);
        }
    }
