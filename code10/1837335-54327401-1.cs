    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication98
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> WinFileList = Directory.GetFiles("AllDirectories[i]", ".", SearchOption.AllDirectories).ToList();
                List<IndexerListModel> models = new List<IndexerListModel>();
                //use left outer join
                var results = (from w in WinFileList
                               join m in models on w equals m.FilePath into wm
                               from m in wm.DefaultIfEmpty()
                               select new { model = m, windFileList = w }).ToList();
            }
        }
        public class IndexerListModel : IEqualityComparer<IndexerListModel>
        {
            public string FilePath = string.Empty;
            public string uniqueID = string.Empty;
        }
     
    }
