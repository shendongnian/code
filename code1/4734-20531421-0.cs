    //resides in IEnumerableStringExtensions.cs
    public static class IEnumerableStringExtensions
    {
       public static IEnumerable<string> Append(this string[] arrayInitial, string[] arrayToAppend)
       {
           string[] ret = new string[arrayInitial.Length + arrayToAppend.Length];
           arrayInitial.CopyTo(ret, 0);
           arrayToAppend.CopyTo(ret, arrayInitial.Length);
    
           return ret;
       }
    }
