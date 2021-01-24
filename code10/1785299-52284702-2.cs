    class XXList : List<XX>
    {
        public void SaveAll()
        {
            foreach (var xx in this) xx.Save();
        }
    }
