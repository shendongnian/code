    public class MyDataGrid : DataGrid
    {
        private const int GRIDSTATE_allowSorting = 0x00000001;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            var allowSorting = AllowSorting;
            var hti = HitTest(e.X, e.Y);
            var newArgs = new MouseEventArgs(e.Button, e.Clicks, -1, -1, e.Delta);
            if (hti.Type == HitTestType.ColumnHeader && hti.Column == 0)
                base.OnMouseUp(newArgs);
            else
                base.OnMouseUp(e);
        }
    }
