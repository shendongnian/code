    class Consumer
    {
        private readonly IFileGenerator fileGenerator;
        Consumer(IFileGenerator, fileGenerator)
        {
            this.fileGenerator = fileGenerator;
        }
        public void SomeMethod(string userInput)
        {
              switch(userInput)
              {
                    case 1: 
                        fileGenerator.GenerateFile(OutputType.Csv);
                        break;
                    case 2: 
                        fileGenerator.GenerateFile(OutputType.Text);
                        break;
                    default:
                        break;
              }
        }
    }
