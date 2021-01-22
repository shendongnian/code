    private void textBox1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetData("Text") != null)
        {
            ApplicationClass app;
            Explorer exp;
            List<ContactItem> draggedContacts;                
            string contactStr;
            contactStr = e.Data.GetData("Text").ToString();
            draggedContacts = new List<ContactItem>();
            app = new ApplicationClass();
            exp = app.ActiveExplorer();
            if (exp.CurrentFolder.DefaultItemType == OlItemType.olContactItem)
            {
                if (exp.Selection != null)
                {
                    foreach (ContactItem ci in exp.Selection)
                    {
                        if (contactStr.Contains(ci.FullName))
                        {
                            draggedContacts.Add(ci);
                        }
                    }
                }
            }
            app = null;
            GC.Collect();
        }
    }
