    public class MyClassThatOpensFiles
    {
        public bool IsDataValid(string filename)
        {
            var filebytes = File.ReadAllBytes(filename);
            DoSomethingWithFile(fileBytes);
        }
    }
