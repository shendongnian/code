    public static class Constant
    {
        public static int Cons1 = 1;
        public static int coNs2 = 2;
        public static int cOns3 = 3;
        public static int CONS4 = 4;
    }
    // Call constants from anywhere
    // Since the class has a unique name, is not necessary
    private void DoSomething(){
    var getCons1 = Constant.Cons1;
    var getCons2 = Constant.coNs2;
    var getCons3 = Constant.cOns3;
    var getCons4 = Constant.CONS4;
     }
