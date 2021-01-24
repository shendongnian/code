    public static class GlobalClass
    {
        public static string myGlobal="";    
    }  
  
    class myClass
    {
        string myClassVariable = "";
        private void method()
        {
            //myGlobal is accessible using this
            GlobalClass.myGlobal ="some value";
            //myClassVariable is accessible here
            myClassVariable = "somevalue";
            if(condition)
            {
                //myClassVariable is also accessible here
                myClassVariable = "somevalue";
                string ifBlockVariable = "";
            }
            //ifBlockVariable is not accessible here
        }
    }
