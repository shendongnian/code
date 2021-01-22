    public class rptobj
    {
        public string FileName { get; set; }
        public byte[] Photo { get; set; }
        private List<rptobj> photos;
        public List<rptobj> GetList()
        {
            if (photos == null)
            {
                photos = LoadPhotos();
            }
            return photos;
        }
        private List<rptobj> LoadPhotos()
        {
            var rslt = new List<rptobj>();
            byte[] rawData;
            var path = HttpContext.Current.Server.MapPath(@"~\images");
            DirectoryInfo di = new DirectoryInfo(path);
            FileSystemInfo[] fis = di.GetFileSystemInfos("*.jpg");
            foreach(var fi in fis){
                rawData = File.ReadAllBytes(string.Format(@"{0}\{1}", path, fi.Name ));
                rslt.Add(new rptobj() { Photo = rawData, FileName = fi.Name });
            }
            return rslt;
        }
    }
