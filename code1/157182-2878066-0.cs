    abstract class Stdout
    {
        public static readonly Stdout Instance = // ...
        public abstract void WriteLine(string s);
        private class Console : Stdout
        {
            public override void WriteLine(string s)
            {
                Console.WriteLine(s);
            }
        }
        private class Gui : Stdout
        {
            public override void WriteLine(string s)
            {
                // append to gtk# textview
            }
        }
    }
