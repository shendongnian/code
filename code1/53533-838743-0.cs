    [
    ComVisible(true),
    GuidAttribute("..."),
    Description("...")
    ]
    public interface IMyComVisibleClass
    {
        // Text from the Description attribute will be exported to the COM type library.
    
        [Description("...")]
        MyResult MyMethod(...);
    
        [Description("...")]
        MyOtherResult MyArrayMethod([In] ref int[] ids,...);
    }
    ...
    [
    ComVisible(true),
    GuidAttribute("..."),
    ProgId("..."),
    ClassInterface(ClassInterfaceType.None),
    Description("...")
    ]
    public class MyComVisibleClass : IMyComVisibleClass
    {
        public MyResult MyMethod(...)
        {
            ... implementation without exception handling ...
        }
    
        public MyOtherResult MyArrayMethod(int[] ids,...)
        {
            ... input parameter does not use ref keyword for .NET clients ...
            ... implementation without exception handling ...
        }
    
        MyResult IMyComVisibleClass.MyMethod(...)
        {
            try
            {
                return this.MyMethod(...);
            }
            catch(Exception ex)
            {
                ... log exception ...
                throw;   // Optionally wrap in a custom exception type
            }
        }
    
        MyOtherResult IMyComVisibleClass.MyArrayMethod(ref int[] ids, ...)
        {
            try
            {
                // Array is passed without ref keyword
                return this.MyArrayMethod(ids, ...);
            }
            catch(Exception ex)
            {
                ... log exception ...
                throw;   // Optionally wrap in a custom exception type
            }
        }
    
    }
