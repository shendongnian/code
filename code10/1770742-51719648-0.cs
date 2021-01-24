    public static class MyExtensionClass 
    {
        public static string GetDetails(this Microsoft.AspNetCore.Http.Internal.DefaultHttpRequest request)
        {
            return request.PathString.Value + " " + ... ; //Construct your string here 
        }
    }
