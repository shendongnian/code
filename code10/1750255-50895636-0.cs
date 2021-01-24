     List<itemInterface> pList = new List<itemInterface>();
        using (StreamReader sr = new StreamReader(APP_FOLDER + fileItem, Encoding.UTF8, true))
        {
            string s = String.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                itemInterface l = new itemInterface(s.Split('\t'));
                
                pList.Add(l);
                
            }
        }
    
        var pSearch = pList.FindAll(i => i.Item.ToLower().Contains(textBox12.Text.ToLower()));
        UpdateItemDataGridView(dataGridView2, pSearch);
