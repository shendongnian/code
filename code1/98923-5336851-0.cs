    public class YourForm : Form
    {
        public YourForm()
        {
            DataGridView _dgv = new DataGridView() { Dock = DockStyle.Fill};
            Controls.Add(_dgv);
        }
        public void CorrectWindowSize()
        {
            int width = WinObjFunctions.CountGridWidth(_dgv);
            ClientSize = new Size(width, ClientSize.Height);
        }
        DataGridView _dgv;
    }
    public static class WinObjFunctions
    {
        public static int CountGridWidth(DataGridView dgv)
        {
            int width = 0;
            foreach (DataGridViewColumn column in dgv.Columns)
                if (column.Visible == true)
                    width += column.Width;
            return width += 20;
        }
    }
