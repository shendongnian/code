    private void textBox1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetData("Text") != null)
        {                
            ApplicationClass app;
            MAPIFolder mapif;
            string contactStr;
            contactStr = e.Data.GetData("Text").ToString();
            app = new ApplicationClass();                
            
            mapif = app.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderContacts);                
            foreach (ContactItem tci in mapif.Items)
            {
                if (contactStr.Contains(tci.FullName))
                {
                    draggedContact = tci; //draggedContact is a global variable for example or a property...
                    break;
                }                    
            }
            mapif = null;
            app.Quit;
            app = null;
            GC.Collect();
        }
    }
