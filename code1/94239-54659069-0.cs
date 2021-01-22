	using System.IO;
	using System.IO.Abstractions;
	 
	namespace ConsoleApp1
	{
	    public class FileProcessorTestable
	    {
	        private readonly IFileSystem _fileSystem;
	 
	        public FileProcessorTestable() : this (new FileSystem()) {}
	 
	        public FileProcessorTestable(IFileSystem fileSystem)
	        {
	            _fileSystem = fileSystem;
	        }
	 
	        public void ConvertFirstLineToUpper(string inputFilePath)
	        {
	            string outputFilePath = Path.ChangeExtension(inputFilePath, ".out.txt");
	 
	            using (StreamReader inputReader = _fileSystem.File.OpenText(inputFilePath))
	            using (StreamWriter outputWriter = _fileSystem.File.CreateText(outputFilePath))
	            {
	                bool isFirstLine = true;
	 
	                while (!inputReader.EndOfStream)
	                {
	                    string line = inputReader.ReadLine();
	 
	                    if (isFirstLine)
	                    {
	                        line = line.ToUpperInvariant();
	                        isFirstLine = false;
	                    }
	 
	                    outputWriter.WriteLine(line);
	                }
	            }
	        }
	    }
	}
	using System.IO.Abstractions.TestingHelpers;
	using Xunit;
	 
	namespace XUnitTestProject1
	{
	    public class FileProcessorTestableShould
	    {
	        [Fact]
	        public void ConvertFirstLine()
	        {
	            var mockFileSystem = new MockFileSystem();
	 
	            var mockInputFile = new MockFileData("line1\nline2\nline3");
	 
	            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);
	 
	            var sut = new FileProcessorTestable(mockFileSystem);
	            sut.ConvertFirstLineToUpper(@"C:\temp\in.txt");
	 
	            MockFileData mockOutputFile = mockFileSystem.GetFile(@"C:\temp\in.out.txt");
	 
	            string[] outputLines = mockOutputFile.TextContents.SplitLines();
	 
	            Assert.Equal("LINE1", outputLines[0]);
	            Assert.Equal("line2", outputLines[1]);
	            Assert.Equal("line3", outputLines[2]);
	        }
	    }
	}
