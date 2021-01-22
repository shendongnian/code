    public static class CheckedListBoxExtension
    {
        public static void CheckAll(this CheckedListBox listbox)
        {
            Check(listbox, true);
        }
        public static void UncheckAll(this CheckedListBox listbox)
        {
            Check(listbox, false);
        }
        private static void Check(this CheckedListBox listbox, bool check)
        {
            Enumerable.Range(0, listbox.Items.Count).ToList().ForEach(x => listbox.SetItemChecked(x, check));
        }
    }
