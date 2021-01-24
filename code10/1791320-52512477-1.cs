    public class C
    {
        [CompilerGenerated]
        private sealed class <>c__DisplayClass1_0
        {
            public DisplayType displayType;
            internal bool <CheckSupport>b__0(Display x)
            {
                return x.DisplayType == displayType;
            }
        }
        public Display[] Displays = new Display[0];
        public bool CheckSupport(DisplayType displayType)
        {
            <>c__DisplayClass1_0 <>c__DisplayClass1_ = new <>c__DisplayClass1_0();
            <>c__DisplayClass1_.displayType = displayType;
            return Displays.Any(<>c__DisplayClass1_.<CheckSupport>b__0);
        }
    }
