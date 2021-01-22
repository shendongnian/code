    public static class MyExtensions
    {
        public static string LineNumber(this Exception ex)
        {
            var index = ex.StackTrace.LastIndexOf(":line ");
            var lineNumberText = ex.StackTrace.Substring(index + ":line ".Length);
            return lineNumberText;
        }
    }   
