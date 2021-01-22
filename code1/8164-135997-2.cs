    public class MyDataGridView : DataGridView
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
                SendKeys.Send("{DOWN}");
            else
                SendKeys.Send("{UP}");
        }
    }
