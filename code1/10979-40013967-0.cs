    static Dictionary<DataGridView, PaintEventHandler> subscriptions = new Dictionary<DataGridView, PaintEventHandler>();
    
    public static void MergeColumns(this DataGridView dg, bool enable, params ColumnGroup[] mergedColumns) {
    
        if(enable) {
            subscriptions[dg] = (s, e) => Dg_Paint(s, e, mergedColumns);
            dg.Paint += subscriptions[dg];
        }
        else {
            if(subscriptions.ContainsKey(dg)) {
                dg.Paint -= subscriptions[dg];
                subscriptions.Remove(dg);
            }
        }
    }
