    public class tbl_Table1 {
    
     [Key]
     public int mpd_Id {
      get;
      set;
     }
     public int Size {
      get;
      set;
     }
    
     public string {
      {
       get;
       set;
      }
     }
    }
    
    public tbl_Table1(tbl_Table2 objTbl_Table2) {
     this.Name = tbl_Table2.NameOfElement.Where(tbl_Table2.SizeFrom <= Size && tbl_Table2.SizeTo >= Size)
    }
