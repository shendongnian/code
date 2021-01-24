    public static class GlobalClass
    {
        public string myGlobal="";    
    }  
  
    Class myClass
    {
        string myClassVariable = "";
        private void method()
        {
            //myGlobal is accessible using this
            GlobalClass.myGlobal ="some value";
            //myClassVariable is accessible here
            myClassVariable = "somevalue";
            If(condition)
            {
                //myClassVariable is also accessible here
                myClassVariable = "somevalue";
                string ifBlockVariable = "";
            }
            //ifBlockVariable is not accessible here
        }
    }
