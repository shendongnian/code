    <!-- language: lang-js -->
        <var>Visual.WIN.ctrlListView.OnShown</var>  : 
        eventSender.Columns.Clear();
        eventSender.SmallImageList = edvWinForm.ImageList16;
        eventSender.ListViewItemSorter = new ListViewColumnSorter();
        var col = eventSender.Columns.Add("Répertoire");
        col.Width = 160;
        col.ImageKey = "Domain";
        col = eventSender.Columns.Add("Fichier");
        col.Width = 180;
        col.ImageKey = "File";
        col = eventSender.Columns.Add("Date");
        col.Width = 120;
        col.ImageKey = "DateTime";
        eventSender.ListViewItemSorter.ColumnsTypeComparer.Add(col.Index, DateTime);
        col = eventSender.Columns.Add("Position");
        col.TextAlign = HorizontalAlignment.Right;
        col.Width = 80;
        col.ImageKey = "Num";
        eventSender.ListViewItemSorter.ColumnsTypeComparer.Add(col.Index, Int32);
        
