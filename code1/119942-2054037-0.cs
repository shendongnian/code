    public class MyDataSet
    {
        public static MyDataSet myDataSet;   
           // This was null 2nd call to getInstance
    
        private DataSet myData = new DataSet();
    
        public static MyDataSet GetInstance()
        {
            if (myDataSet == null)
            {
                myDataSet = new MyDataSet();      // Changed at this point
                return myDataSet;
            }
            else
            {
                return myDataSet;
            }
        }
