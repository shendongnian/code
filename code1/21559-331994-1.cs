      public partial class FooRow
      {    
           private void myColumnChanging Handler(object sender, EventArgs e)
           {
                // Implementation
           }
           private void myColumnChanged Handler(object sender, EventArgs e)
           {
                // Implementation
           }
           public void RegisterEvents()
           {
              ((DataRow)this).Table.ColumnChanging += myColumnChanging; 
              ((DataRow)this).Table.ColumnChanged += myColumnChanged; 
           }
       }
