    public class AMList : List<AM>
    {
        public void SaveItems()
        {
            foreach (var item in this)
            {
                item.Save();
            }
        }
    }
