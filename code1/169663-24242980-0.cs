    public static class UnitTestDetector
    {
        public static readonly HashSet<string> UnitTestAttributes = new HashSet<string> 
        {
            "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute",
            "NUnit.Framework.TestFixtureAttribute",
        };
        public static bool IsRunningInUnitTest
        {
            get
            {
                foreach (var f in new StackTrace().GetFrames())
                    if (f.GetMethod().DeclaringType.GetCustomAttributes(false).Any(x => UnitTestAttributes.Contains(x.GetType().FullName)))
                        return true;
                return false;
            }
        }
    }
