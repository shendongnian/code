    public class FInfo
    {
        public string FilePath { get; set; }
        public string MD5Hash { get; set; }   
        public override string ToString() => $"FilePath:{FilePath}, MD5Hash:{MD5Hash}";
    }
