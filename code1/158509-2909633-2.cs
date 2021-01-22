    using MyNamespace.Collections; // to use SpecialArray
    using MyNamespace.BusinessLogic.Filtering; // to use custom log filtering business logic
    namespace MyNamespace
    {
        public static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main2()
            {
                SpecialArray<Logs> logs;
                var filteredLogs = logs.Filter();
            }
        }
    }
