    public class NameValueDTO
    {
        public string Name { get; set; }
        public string Value{ get; set; }
    }
    
    var T1Row = db.T1.AsNoTracking().Where(s => s.Name == "text1").Select(i => new NameValueDTO { Name = i.Name, Value = i.Value }).FirstOrDefault();
    if (T1Row == null)
        T1Row = db.T2.AsNoTracking().Where(s => s.Name == "text2").Select(i => new NameValueDTO { Name = i.Name, Value = i.Value }).FirstOrDefault();
