    [Database(Name = "AdventureWorks")]
    public class AdventureWorks : DataContext
    {
        //public Table<DirInfo> DirectoryInformation;
        public AdventureWorks(string connection) : base(connection) { }
        public Table<DirectoryInformation> DirectoryInformation;
    }
    [Table(Name = "DirectoryInformation")]
    public class DirectoryInformation
    {
        [Column(DbType="varchar(50)")]
        public string DirectoryName;
        [Column(DbType = "varchar(255)")]
        public string DirectoryDescription;
    }
