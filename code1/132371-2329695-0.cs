    public interface IExecutionResultsRepository
    {
      void SaveExecutionResults(string name, ExecutionResults results);
      ExecutionResults GetExecutionResults(int id);
    }
