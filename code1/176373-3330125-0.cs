       [TestClass]
       public class UnitTest1 {
          class MyTable : TypedTableBase<MyRow> {
             public MyTable() {
                Columns.Add("Col1", typeof(int));
                Columns.Add("Col2", typeof(int));
             }
    
             protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new MyRow(builder);
             }
          }
    
          class MyRow : DataRow {
             public MyRow(DataRowBuilder builder) : base(builder) {
             }
    
             public int Col1 { get { return (int)this["Col1"]; } }
             public int Col2 { get { return (int)this["Col2"]; } }
          }
    
          DataView _viewCol1Asc;
          DataView _viewCol2Desc;
          MyTable _table;
          int _countToTake;
    
          [TestMethod]
          public void MyTestMethod() {
             _table = new MyTable();
    
    
             int count = 50000;
             for (int i = 0; i < count; i++) {
                _table.Rows.Add(i, i);
             }
    
             _countToTake = _table.Rows.Count / 30;
             Console.WriteLine("SortWithLinq");
             RunTest(SortWithLinq);
             Console.WriteLine("Use DataViews");
             RunTest(UseSoredDataViews);
          }
    
          private void RunTest(Action method) {
             int iterations = 100;
             Stopwatch watch = Stopwatch.StartNew();
             for (int i = 0; i < iterations; i++) {
                method();
             }
             watch.Stop();
             Console.WriteLine("   {0}", watch.Elapsed);
          }
    
          private void UseSoredDataViews() {
             if (_viewCol1Asc == null) {
                _viewCol1Asc = new DataView(_table, null, "Col1 ASC", DataViewRowState.Unchanged);
                _viewCol2Desc = new DataView(_table, null, "Col2 DESC", DataViewRowState.Unchanged);
             }
    
             var rows = _viewCol1Asc.Cast<DataRowView>().Take(_countToTake).Select(vr => (MyRow)vr.Row);
             IterateRows(rows);
             rows = _viewCol2Desc.Cast<DataRowView>().Take(_countToTake).Select(vr => (MyRow)vr.Row);
             IterateRows(rows);
          }
    
          private void SortWithLinq() {
             var rows = _table.OrderBy(row => row.Col1).Take(_countToTake);
             IterateRows(rows);
             rows = _table.OrderByDescending(row => row.Col2).Take(_countToTake);
             IterateRows(rows);
          }
    
          private void IterateRows(IEnumerable<MyRow> rows) {
             foreach (var row in rows)
                if (row == null)
                   throw new Exception("????");
          }
       }
