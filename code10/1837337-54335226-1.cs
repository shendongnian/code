    public class IndexerListModel
    {
        public string UniqueID { get; set; }
        public string FilePath { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myPathList = Directory.GetFiles(@"C:\Windows").ToList();
            List<IndexerListModel> myModelList = new List<IndexerListModel> {
                new IndexerListModel {
                UniqueID= "0001",
                FilePath = @"C:\Windows\bfsvc.exe"
            },
                new IndexerListModel {
                UniqueID= "0002",
                FilePath = @"C:\Windows\diagwrn.xml"
            }
            };
            var result = myPathList.Where(path => !myModelList.Any(model => model.FilePath == path)).ToList();
        }
    }
