    using System.Windows.Forms;
    public class MyPanel : Panel
    {
        public Button AcceptButton { get; set; }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                AcceptButton?.PerformClick();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
