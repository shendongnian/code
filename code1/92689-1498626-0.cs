    using System;
                using System.Windows.Forms;
                namespace WindowsFormsApplication6
                {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Form form = new Form())
            {
                form.ContextMenuStrip = new ContextMenuStrip();
                ToolStripItem addMenuItem = form.ContextMenuStrip.Items.Add("Add");
                ToolStripItem deleteMenuItem = form.ContextMenuStrip.Items.Add("Delete");
                form.ContextMenuStrip.ItemClicked += (sender, e) =>
              {
                  if (e.ClickedItem == addMenuItem)
                  {
                      MessageBox.Show("Add Menu Item Clicked.");
                  }
                  if (e.ClickedItem == deleteMenuItem)
                  {
                      MessageBox.Show("Delete Menu Item Clicked.");
                  }
              };
                Application.Run(form);
            }
        }
    }
}
