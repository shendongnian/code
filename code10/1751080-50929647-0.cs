    public class MyFileInfo
    {
        public string FileName { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public interface IDateTimeProvider
    {
        DateTime GetCurrentTime();
    }
    public interface IMyFileSystemService
    {
        IEnumerable<MyFileInfo> GetFileInfos(string folder);
        void DeleteFile(MyFileInfo myFileInfo);
    }
    public class MyService
    {
        private readonly IMyFileSystemService _myFileSystemService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public MyService(IMyFileSystemService myFileSystemService, IDateTimeProvider dateTimeProvider)
        {
            _myFileSystemService = myFileSystemService;
            _dateTimeProvider = dateTimeProvider;
        }
        public void Delete(string folder, int days)
        {
            var files = _myFileSystemService.GetFileInfos(folder);
            foreach (var file in files)
            {
                var deleteOlderThan = _dateTimeProvider.GetCurrentTime().AddDays(-days);
                if (file.CreationTime >= deleteOlderThan) continue;
                _myFileSystemService.DeleteFile(file);
            }
        }
    }
