    interface IFileGenerator
    {
        void GenerateFile(string userInput);
    }
    class FileGenerator : IFileGenerator
    {
        // inject both or your file services into the constructor
        public void GenerateFile(string userInput)
        {
             switch(userInput)
             {
                  // call the correct service here
             }
        }
