    class ItemTpComparer : IComparer<itemTp>
    {
        private IList<codeTp> otherList;
        public ItemTpComparer(IList<codeTp> otherList)
        {
            this.otherList = otherList;
        }
        public int Compare(itemTp a, itemTp b)
        {
            return otherList.IndexOf(a.Code) - otherList.IndexOf(b.Code);
        }
    }
