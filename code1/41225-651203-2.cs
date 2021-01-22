    // A delegate that matches the signature of
    // public static DataSet C      (out string SpName)
    public delegate  DataSet GetName(out string name);
    public class DataAccess
    {
       // ...
       static public string GetSpName(GetName nameGetter)
       {
           // TODO: Handle case where nameGetter == null
           string spName;
           nameGetter(out spName);
           return spName;
       }
       // ...
    }
    // ...
    public void SomeFunction()
    {
        // Call our GetSpName function with a new delegate, initialized
        // with the function "C"
        ButtonC.Text = DataAccess.GetSpName(new GetName( Foobar.C ))
    }
