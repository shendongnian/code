     public class ProcessStepFactory : IProcessStepFactory
    {
        private readonly ITableCountTest _table;
        private readonly ICompareTest _compareTest;
        private readonly IStrategyManager _manager; //code added
        public ProcessStepFactory(ITableCountTest table, ICompareTest compareTest,IStrategyManager manager)
        {
            _table = table;
            _compareTest = compareTest;
            _manager = manager;
        }
        public IProcessStep CreateProcessStep(string stepName, FileInfo file, DateTime s, DateTime d, int id)
        {
            return _manager.Process(stepName);
        }
    }
