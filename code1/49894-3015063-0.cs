    public class ControlKeyInterceptingDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Debug.WriteLine(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
