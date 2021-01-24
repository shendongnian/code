    public class RectangleGroups : IEnumerable<RectangleGroup> {
        List<RectangleGroup> groups;
        public RectangleGroups() {
            init();
        }
    
        public RectangleGroups(IEnumerable<Rectangle> rs) {
            init();
    
            foreach (var r in rs.OrderBy(r => r.Loc.Distance(PointExt.PointZero)))
                Add(r);
        }
    
        private void init() {
            groups = new List<RectangleGroup>();
        }
    
        public void Add(Rectangle r) {
            var found = false;
            foreach (var g in groups) {
                found = g.BelongsToGroup(r);
                if (found) {
                    g.Add(r);
                    break;
                }
            }
            if (!found)
                groups.Add(new LocationGroup().Add(r));
        }
    
        public IEnumerator<LocationGroup> GetEnumerator() => groups.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
