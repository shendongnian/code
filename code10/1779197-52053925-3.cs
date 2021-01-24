    public interface IPanel
    {
        public long Id { get; set; }
    }
    [Table("tbl_panel", Schema = "Db1")]
    public class Db1Panel : IPanel
    {
        public long Id { get; set; }
    }
    [Table("tbl_panel", Schema = "Db2")]
    public class Db2Panel : IPanel
    {
        public long Id { get; set; }
    }
