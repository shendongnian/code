    public class MyDataGrid : DataGrid
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            var a = AllowSorting;
            var hti = HitTest(e.X, e.Y);
            if (hti.Type == HitTestType.ColumnHeader && hti.Column == 0) //← The column index
                AllowSorting = false;
            base.OnMouseUp(e);
            AllowSorting = a;
        }
    }
