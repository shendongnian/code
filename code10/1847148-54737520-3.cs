    enum OutputType
    {
        Csv,
        Text
    }
    interface IFileGenerator
    {
        void GenerateFile(OutputType outputType);
    }
    class FileGenerator : IFileGenerator
    {
        // inject both or your file services into the constructor
        public void GenerateFile(OutputType outputType)
        {
             switch(outputType)
             {
                  // call the correct service here
             }
        }
