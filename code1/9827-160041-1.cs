    public class MyDataTable : DataTable
    {
        public override void EndInit()
        {
            base.EndInit();
            this.TableNewRow += delegate(object sender, DataTableNewRowEventArgs e) { };
        }
        
        protected override void OnTableNewRow(DataTableNewRowEventArgs e)
        {
            base.OnTableNewRow(e);
            // your code here
        }
    }
