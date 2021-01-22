    public void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        Clipboard.SetText("<#KEYWORD#>");
        IDataObject dObject = Clipboard.GetDataObject();
    
        //This is extremely buggy coming from VSTO, this is why the clipboard is used.
        DoDragDrop(dObject, DragDropEffects.All);
    }
    void Application_WindowSelectionChange(Microsoft.Office.Interop.Word.Selection Sel)
    {
        if (Sel.Range.Text == "<#KEYWORD#>")
        {
            Sel.Range.Text = string.Empty;
            // Do some action
        }
    }
