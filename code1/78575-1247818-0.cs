    ListViewItem listitem = new ListViewItem { Text = (item.KODU ?? "").ToString() };
    listitem.SubItems.Add(
        (item.TB_TL == null || String.IsNullOrEmpty(item.TB_IL.ADI)) 
        ? "EMPTY ROW" : item.TB_IL.ADI
    );
