    public class AA
    {
    //some variables
    }
    public class BB : AA
    {
        public BB(AA aa)
        {
        //Set BBs variables to those in AA
        someVariable= aa.someVariable
        }
 
        public int SomeExtraProperty{get;set;}
    }
