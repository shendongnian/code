    public interface ICodeEntity { }
    public interface IObjectEntity { }
    public class Column: IObjectEntity
    {
        public string name;
        public System.Data.DbType type;
    }
    public class Table: IObjectEntity
    {
        public List<Column> columns = new List<Column>();
        public string alias;
    }
    public class Where : ICodeEntity { }
    public class GroupBy : ICodeEntity { }
    public class OrderBy : ICodeEntity { }
    public class Select : Table, ICodeEntity
    {
        public List<Table> joinList = new List<Table>();
        public Where where;
        public GroupBy groupBy;
        public OrderBy orderBy;
    }
    public class Condition : ICodeEntity { }
    public class If : ICodeEntity
    {
        public Condition condition;
        public List<ICodeEntity> codeList = new List<ICodeEntity>();
    }
