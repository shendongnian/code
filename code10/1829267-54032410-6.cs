    public class Extensions
    {
         public void Update(this State aDifferentStateObject)
         {
            // the world is as it should be
            aDifferentStateObject.StateVar1 = "bang!!!" // compiler error
         }
    }
