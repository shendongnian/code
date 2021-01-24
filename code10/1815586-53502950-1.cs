        private ToolStripButton closeButton = new ToolStripButton();  <-- global variable
      
        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem tsi in ts.Items)
            { 
                if (tsi.Name.Equals("closeToolStripButton"))
                {
                    closeButton = tsi as ToolStripButton;
                }
                else if (tsi.Name.Equals("printToolStripButton"))
                {
                    printButton = tsi as ToolStripButton;
                }
            }
            ts.Items.Remove(printButton);
            ToolStripButton b = new ToolStripButton();
            b.ImageIndex = printButton.ImageIndex;
            b.Visible = true;
            ts.Items.Insert(0, b);
            b.Click += new EventHandler(this._start_Printer); //<-- this starts the printer event where i "PerformClick() on the initialized closeButton"
            printprevDialog.WindowState = FormWindowState.Maximized;
            printprevDialog.ShowDialog();
        }
        public void _start_Printer(object sender, EventArgs e) // <--- then i just performed the close click here right after i hit the print button
        {
            printDocument1.Print();
            closeButton.PerformClick(); // <-- this way im not violating cross thread operations
        }
