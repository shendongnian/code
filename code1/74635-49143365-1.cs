    class myClass
    {
        public void print(string mess)
        {
            Console.WriteLine(mess);
        }
    }
    class myOtherClass
    {
        public static void print(string mess)
        {
            Console.WriteLine(mess);
        }
        public void printMe(string mess)
        {
            Console.WriteLine(mess);
        }
    }
    public static class Test
    {
        public static void Main()
        {
            myClass mc = new myClass();
            mc.print("hello");
            myOtherClass moc = new myOtherClass();
            myOtherClass.print("vhhhat?");
            moc.printMe("test me");
            
        }
    }
