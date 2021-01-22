    public interface IBatchFile
    {
        void Execute();
    }
    public class BatchFileType1 : IBatchFile
    {
        private string _filename;
        public BatchFileType1(string filename)
        {
            _filename = filename;
        }
        ...
        public void Execute()
        {
            ...
        }
    }
    public class BatchFileType2 : IBatchFile
    {
        private string _filename;
        public BatchFileType2(string filename)
        {
            _filename = filename;
        }
        ...
        public void Execute()
        {
            ...
        }
    }
