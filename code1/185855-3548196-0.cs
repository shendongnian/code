    public class Page
    {
        public string Name { get; set; }
    }
    public class PageQueue
    {
        private ConcurrentDictionary<int, ConcurrentQueue<Page>> pages =
            new ConcurrentDictionary<int, ConcurrentQueue<Page>>();
        public void Enqueue(int id, Page page)
        {
            ConcurrentQueue<Page> queue;
            queue = this.pages.GetOrAdd(id, _ => new ConcurrentQueue<Page>());
            queue.Enqueue(page);
        }
        public bool TryDequeue(int id, out Page page)
        {
            ConcurrentQueue<Page> queue;
            if (this.pages.TryGetValue(id, out queue))
            {
                return queue.TryDequeue(out page);
            }
            page = null;
            return false;
        }
    }
