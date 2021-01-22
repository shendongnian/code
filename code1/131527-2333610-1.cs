    static public InvertSelection(ListView lv) {
        // Build a hashset of the currently selected indicies
        int[] selectedArray = new int[lv.SelectedIndices.Count];
        lv.SelectedIndices.CopyTo(selectedArray, 0);
        HashSet<int> selected = new HashSet<int>();
        selected.AddRange(selectedArray);
        // Reselect everything that wasn't selected before
        lv.SelectedIndices.Clear();
        for (int i=0; i<lv.VirtualListSize; i++) {
            if (!selected.Contains(i))
                lv.SelectedIndices.Add(i);
        }
    }
