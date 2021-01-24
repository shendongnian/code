    public abstract class PanelBase
    {
        public long Id { get; set; }
        // other properties
    }
    [Table("tbl_panel", Schema = "Db1")]
    public class Db1Panel : PanelBase{}
    [Table("tbl_panel", Schema = "Db2")]
    public class Db2Panel : PanelBase{}
