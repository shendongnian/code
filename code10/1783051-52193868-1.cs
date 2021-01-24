    public class FolderEntries {
        public string Data { get; set; }
        public DateTime? FolderDateTime { get; set; }
    }
    var result =
      (from s1 in list select new FolderEntries(){
    	  Data = s1.Data,
    	  FolderDateTime = s1.StartTime
      }).Concat
      (from s2 in list select new FolderEntries {
    	  Data = s2.Data,
    	  FolderDateTime = s2.EndTime
      }).OrderBy(x=>x.FolderDateTime);
