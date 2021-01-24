    public class FileInfoEqualityComparer : IEqualityComparer<MyFileInfo> {
        public bool Equals(MyFileInfo info1, MyFileInfo info2) {
            return info1.ArchiveLocation + "\\" + info1.ArchiveName == info2.ArchiveLocation + "\\" + info2.ArchiveName;
        }
        public int GetHashCode(MyFileInfo info) {
            return (info.ArchiveLocation + "\\" + info.ArchiveName).GetHashCode();
        }
    }
