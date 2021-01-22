    private class Derived : Program.Base
    {
        // Methods
        public Derived()
        {
            base..ctor(new Func<string>(Program.Derived.<.ctor>b__0));
            return;
        }
    
        [CompilerGenerated]
        private static string <.ctor>b__0()
        {
            string CS$1$0000;
            CS$1$0000 = CS$1$0000.CheckNull();
        Label_0009:
            return CS$1$0000;
        }
    
        private string CheckNull()
        {
            string CS$1$0000;
            CS$1$0000 = "Am I null? " + ((bool) (this == null));
        Label_0017:
            return CS$1$0000;
        }
    }
