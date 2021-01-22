    public class BooleanHolder{       
        public bool BooleanEvaluator {get;set;}
    }
    
    public class DatabaseInserter{
        BooleanHolder holder;
        
        public DatabaseInserter(BooleanHolder holder){
            this.holder = holder;
        }
        public void Insert(SqlConnection connection) {
              ...random connection stuff
              cmd.Parameters["IsItTrue"].Value = holder.BooleanEvalutar;
              ...
        }
    }
    
    public static void Main(object[] args) {
        BooleanHolder h = new BooleanHolder();
        DatabaseInserter derClass = new DatabaseInserter(h);
        derClass.Insert(new sqlConnection);
    }
