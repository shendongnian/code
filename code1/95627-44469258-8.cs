    public static class LvSort
    {
        static List<ListView> LVs = new List<ListView>();
        public static void registerLV(ListView lv)
        {
            if (!LVs.Contains(lv) && lv is ListView)
            {
                LVs.Add(lv);
                lv.ColumnClick +=Lv_ColumnClick;
            }
        }
        public static void unRegisterLV(ListView lv)
        {
            if (LVs.Contains(lv) && lv is ListView)
            {
                LVs.Remove(lv);
                lv.ColumnClick -=Lv_ColumnClick;
            }
        }
        private static void Lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;
            int c = e.Column;
            bool asc = (lv.Tag == null) || ( lv.Tag.ToString() != c+"");
            var items = lv.Items.Cast<ListViewItem>().ToList();
            var sorted =  asc ? items.OrderByDescending(x => x.SubItems[c].Text).ToList() :
                                items.OrderBy(x => x.SubItems[c].Text).ToList();
            lv.Items.Clear();
            lv.Items.AddRange(sorted.ToArray());
            if (asc) lv.Tag = c+""; else lv.Tag = null;
        }
    }
