    public class ClassA
    {
        public void CallMe();
    }
    
    public class ClassB
    {
        public void WannaCallYou(ClassA a)
        {
            a.CallMe();
        }
    }
