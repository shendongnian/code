    private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
               
                this.Application.ItemSend += Application_ItemSend;
            }
    
            private void Application_ItemSend(object Item, ref bool Cancel)
            {
                MessageBox.Show("Test");
            }
