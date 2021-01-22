    interface IMyInterface
    {
         void GetResults(out DataTable results);
         void GetResults(out IEnumerable<string> results);
    }
