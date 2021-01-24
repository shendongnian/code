    public class Table : List<Row>
    {
    	public Table(IEnumerable<Row> rows) : base(rows) {}
    }
----------
    table = new Table(tableObject.Where(x => x.Value.Equals("")));
