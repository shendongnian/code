    class Summary
    {
        public int custId { get; set; }
        public int ordId { get; set; }
        public List<Item> items { get; set; }
        public void Filter(int id)
        {
            int i;
            i = 0;
            while (i < items.Count)
            {
                if (items[i].prodId == id)
                {
                    i++;
                }
                else
                {
                    items.RemoveAt(i);
                }
            }
        }
    }
