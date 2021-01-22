    public class MyDataGridView : DataGridView
    {
         public MyDataGridView()
         {
         }
         protected override void OnCellClick(DataGridViewCellEventArgs e)
         {
              if (!Columns[e.ColumnIndex].ReadOnly)
              {
                   base.OnCellClick(e);
              }
         }
    }
