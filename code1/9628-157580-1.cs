     public class MyClass
     {
         private Integer age = 42;  // **<----------- at class scope, not local....**
         public void MyMethod()
         {
             Dictionary<Integer, string> myDict = new Dictionary<Integer, string>();
             // Put in a value, keep a reference.
             myDict[age] = age.ToString();
             foreach (KeyValuePair<Integer,string> kvp in myDict)
             {
                  // Lock the key if there is any chance some else
                  // will now change it...
                  lock ( kvp.Key )                        // In another thread...
                  {                                       //
                      myDict[kvp.Key] = ToGreek(kvp.Key); // age++; 
                  }
             }
        }
    }
        
