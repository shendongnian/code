    public interface IAlgorithm
    {
        void UpdateProgress(double percent);
        void Complete(bool success);
        void Error(string error); // Or (Exception error), if you want to pass an exception
    }
    public interface IAlgorithmFactory
    {
        IAlgorithm StartAlgorithm(string name);
    }
