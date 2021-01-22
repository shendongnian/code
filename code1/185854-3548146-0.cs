    public class PageQueue
    {
        private ConcurrentDictionary<int, ConcurrentQueue<Page>> pages = new ConcurrentDictionary<int, ConcurrentQueue<Page>>();
        private object locker = new object();
        public void Add(int id , Page page)
        {
            lock(locker)
            {
              if (!this.pages.ContainsKey(id))
                  this.pages[id] = new ConcurrentQueue<Page>();
            }
            this.pages[id].Enqueue(page);
        }
        public Page GetAndRemove(int id)
        {
            Page lp = null;
            
            lock(locker)
            {
              if(this.pages.ContainsKey(id))
                this.pages[id].TryDequeue(out lp);
            }
            return lp;
        }
    }
