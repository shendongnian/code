    public class Container
    {
        private readonly Dictionary<int, MyModel> items = new Dictionary<int, MyModel>();
        private readonly SortedList removedIds = new SortedList();
        private int maxId = 0;
        public int Add(MyModel model)
        {
            int id;
            if (removedIds.Count > 0)
            {
                id = (int) removedIds.GetByIndex(0);
                removedIds.RemoveAt(0);
            }
            else
            {
                id = maxId++;
            }
            model.ID = id;
            items.Add(id, model);
            return id;
        }
        public void RemoveById(int id)
        {
            if (!items.ContainsKey(id))
                throw new ArgumentException(); // or just return
            items.Remove(id);
            removedIds.Add(id, id);
        }
    }
