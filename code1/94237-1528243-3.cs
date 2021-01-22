    // File IO is done outside prior to this call, so in the level 
    // above the caller would open a file and pass in the stream
    public class MyClassThatNoLongerOpensFiles
    {
        public bool IsDataValid(Stream stream) // or byte[]
        {
            DoSomethingWithStreamInstead(stream); // can be a memorystream in tests
        }
    }
