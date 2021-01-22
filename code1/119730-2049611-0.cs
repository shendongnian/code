    public class Hierarchy<T> where T: HierarchyItem {
        List<T> items;
        public Hierarchy() {
            items = new List<T>();
        }
        public void AddItem(T item) {
            items.Add(item);
        }
        public List<T> Search(string searchText) {
            List<T> results = new List<T>();
            foreach (T item in items) {
                if (item.DisplayText().ToLower().Contains(searchText.ToLower())) {
                    results.Add(item);
                }
            }
            return results;
        }
    }
