    public class BatchFile {
        private batchFileName;
    
        private BatchFile(String filename) {
            this.batchFileName = filename;
        }
        public const static BatchFile batch1 = new BatchFile("file1");
        public const static BatchFile batch2 = new BatchFile("file2");
        
        public String getFileName() { return batchFileName; }
    }
