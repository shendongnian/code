    public interface IStrategyManager
    {
        IProcessStep Process(string stepName);
    }
    public class StrategyManager : IStrategyManager
    {
        private Dictionary<string, IProcessStep> dictionary = new Dictionary<string, IProcessStep>();
        public StrategyManager()
        {
            dictionary.Add("TABLE", new TableCountTest());
            dictionary.Add("COMPARE", new CompareTest());
        }
        public IProcessStep Process(string stepName)
        {
            return dictionary[stepName]; //returns the required object as per stepName
        }
    }
