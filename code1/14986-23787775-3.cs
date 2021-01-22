    public static class Constant
    {
        public static readonly int Cons1 = 1;
        public static readonly int coNs2 = 2;
        public static readonly int cOns3 = 3;
        public static readonly int CONS4 = 4;
    }
    // Call constants from anywhere
    // Since the class has a unique and recognizable name, Upper Case might might lose its charm
    private void DoSomething(){
    var getCons1 = Constant.Cons1;
    var getCons2 = Constant.coNs2;
    var getCons3 = Constant.cOns3;
    var getCons4 = Constant.CONS4;
     }
