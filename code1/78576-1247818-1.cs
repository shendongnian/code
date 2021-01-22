    string EmptyRowIfNull<T>(T o, Func<T, string> p) {
       string s;
       if (o != null) {
           s = p(o);
       }
       return string.IsNullOrEmpty(s) ? "EMPTY ROW" : s;
    }
    listitem.SubItems.Add(EmptyRowIfNull(item.TB_IL, t => t.ADI));
    listitem.SubItems.Add(EmptyRowIfNull(item.TB_TESIS_TIPI, t => t.TIP_AD));
    listitem.SubItems.Add(EmptyRowIfNull(item.TB_TESIS_TURU, t => t.TESIS_TURU));
