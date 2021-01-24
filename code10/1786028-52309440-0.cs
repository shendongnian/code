    public class Row{
        //whatever you have inside it
        public string MyValue{get;set;}
    }
    
    public class Table{
        public List<Row> Rows{get;set;}
    }
    
    Table table = new Table();
    //renaming tableObject to bigListOfRows
    table.Rows = bigListOfRows.Where(x => x.MyValue.Equals("")).ToList();
