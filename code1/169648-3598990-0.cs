    /// <summary>
    /// Detects if we are running inside a unit test.
    /// </summary>
    public static class UnitTestDetector
    {
        static UnitTestDetector()
        {
            UnitTestDetector.IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith("Microsoft.VisualStudio.QualityTools.UnitTestFramework"));
        }
        public static bool IsInUnitTest { get; private set; }
    }
