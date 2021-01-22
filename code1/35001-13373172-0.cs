        public static Action<Func<TabPage, bool>> GetTabHider(this TabControl container) {
            if (container == null) throw new ArgumentNullException("container");
            var orderedCache = new List<TabPage>();
            var orderedEnumerator = container.TabPages.GetEnumerator();
            while (orderedEnumerator.MoveNext()) {
                var current = orderedEnumerator.Current as TabPage;
                if (current != null) {
                    orderedCache.Add(current);
                }
            }
            return (Func<TabPage, bool> where) => {
                if (where == null) throw new ArgumentNullException("where");
                container.TabPages.Clear();
                foreach (TabPage page in orderedCache) {
                    if (where(page)) {
                        container.TabPages.Add(page);
                    }
                }
            };
        }
