    // extension method:
    public static class SomeExtentionMethods
    {
        public static T SelfOrDefault<T>(this T elem)
            where T : class, new()     /* must be class, must have ctor */
        {
            return elem ?? new T();    /* return self or new instance of T if null */
        }
    }
    
    // your code now becomes very easily readable:
    Obj someObj = getYourObjectFromDeserializing();
    // this is it applied to your code:
    var mySalary = applicationForm.SelfOrDefault().
        employeeInfo.SelfOrDefault().
        workingConditions.SelfOrDefault().
        salary;
    // now test with one if-statement:
    if(mySalary.IsEmpty())
       // something in the chain was empty
    else
       // all's well that ends well :)
