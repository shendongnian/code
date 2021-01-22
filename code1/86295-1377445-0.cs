    public class MyListView : ListView
    {
        public MyListView()
        {
            View = View.Details;
            Columns.Add(Column1);
            Columns.Add(Column2);
            Columns.Add(Column3);
        }
        private readonly ColumnHeader Column1 = new ColumnHeader();
        private readonly ColumnHeader Column2 = new ColumnHeader();
        private readonly ColumnHeader Column3 = new ColumnHeader();
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Constant width
            Column1.Width = 200;
            // 50% of the ListView's width
            Column2.Width = (ClientSize.Width/2);
            // Fill the remaining width, but no less than 100 px
            Column3.Width = Math.Max(100, ClientSize.Width - (Column1.Width + Column2.Width));
        }
    }
