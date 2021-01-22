    public class BB : AA
    {
        private AA _aa;
        public BB(AA aa)
        {
        //Set BBs variables to those in AA
        _aa=aa;
        }
 
        public int SomeExtraProperty{get;set;}
        //override inherted members and just delegate to the internal object
        public override int SomeMethod()
        {
           return _aa.SomeMethod();
        }
    }
