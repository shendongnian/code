      public TValue Value { get; set; }
  
      public override string ToString()
      {
           if (Value is decimal) 
           {
                  // Code not cleaned up yet
                 // Some code and values defined in base class
                mstrValue = Value.ToString();
                decimal mdecValue;
                decimal.TryParse(mstrValue, out mdecValue);
                
                mstrValue = decimal.Round(mdecValue).ToString();
                mstrValue = mstrValue + mstrUnitOfMeasurement;
                return mstrValue;
                 
              
            else 
            {
                // Simply return a string
                string str = Value.ToString() +  mstrUnitOfMeasurement;
                return str;
             }
          
            
           
      }
}
    public class SaturatedFat : FoodCountWithDailyValue<decimal>
    {
        public SaturatedFat()
        {
            mUnit = Unit.g;
        }
    }
    public class Fiber : FoodCount<int>
    {
        public Fiber()
        {
            mUnit = Unit.g;
        }
    }
