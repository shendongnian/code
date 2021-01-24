    public class gridviewdata
    {
       public string content { get; set; }
       public int row { get; set; }
       public int cell { get; set; }
    
       public gridviewdata(string content, int row, int cell)
       {
           this.content = content;
           this.row = row;
           this.cell = cell;
       }
    }
