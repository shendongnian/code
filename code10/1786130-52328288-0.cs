    public class BackupBundle : IEnumerable<IFileBackup>
    {
        private readonly List<IFileBackup> _backups = new List<IFileBackup>();
        // default constructor creates default implementations
        public BackupBundle()
            : this(new List<IFileBackup> {new BackUpMechanismA(), new BackUpMechanismB()}) {}
        // allow users to add custom backups
        public BackupBundle(IEnumerable<IFileBackup> backups)
        {
            foreach (var backup in backups)
                Add(backup);
        }
        public void Add(IFileBackup backup)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));
            _backups.Add(backup);
        }
        public IEnumerator<IFileBackup> GetEnumerator()
        {
            foreach (var backup in _backups)
                yield return backup;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class Caller
    {
        private readonly IEnumerable<IFileBackup> _backups;
        public Caller(IEnumerable<IFileBackup> backups)
        {
            _backups = backups ?? throw new ArgumentNullException(nameof(backups));
        }
        public async Task BackupFile(byte[] file)
        {
            foreach (var b in _backups)
            {
                try
                {
                    await b.Backup(file);
                    break;
                }
                catch (Exception e) { }
            }
        }
    }
