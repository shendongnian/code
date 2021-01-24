    public class SampleClass
    {
        private readonly string OutputDirectory;
    
        public SampleClass(string outputDirectory = ".")
        {
            OutputDirectory = outputDirectory;
        }
    
        public void WriteData(string data)
        {
            File.AppendAllText($"{OutputDirectory}\\data.bin", data);
        }
    }
    
    [TestClass]
    public class SampleClassTest
    {
        [TestMethod]
        public void WriteDataTest()
        {
            var sut = new SampleClass("..\\..\\..\\ChatProject\\bin\\Debug");
            sut.WriteData("data");
        }
    }
