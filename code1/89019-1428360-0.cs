    public class ThisThing
    {
        private DataSet myDS = new DataSet();
    
        //Populate your DataSet as normal
    
        public DataSet ChangeLocation(int CurrentSectionNumber)
        {    
            myDS.Table[0] = myDS.Table[CurrentSectionNumber]
        }
    }
