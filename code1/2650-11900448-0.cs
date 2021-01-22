    public interface IDocumentService
    {
        public string BuildTrustedRelationship(string privateKey);
        public byte[] ReadFile(string token, string fileName);
        public void WriteFile(string token, string fileName, byte[] file);
    }
