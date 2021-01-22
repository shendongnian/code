     webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(webBrowser1_PreviewKeyDown);       
    
    ....
    
     private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
         Console.WriteLine(e.KeyCode.ToString() + "  " + e.Modifiers.ToString());
         if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V) {
             MessageBox.Show("ctrl-v pressed");
         }
     }
