    public class LocationGroups : IEnumerable<LocationGroup> {
        List<LocationGroup> groups;
        public LocationGroups() {
            init();
        }
    
        public LocationGroups(IEnumerable<Rectangle> lts) {
            init();
    
            foreach (var lt in lts.OrderBy(lt => lt.Loc.Distance(PointExt.PointZero)))
                Add(lt);
        }
    
        private void init() {
            groups = new List<LocationGroup>();
        }
    
        public void Add(Rectangle lt) {
            var found = false;
            foreach (var g in groups) {
                found = g.BelongsToGroup(lt);
                if (found) {
                    g.Add(lt);
                    break;
                }
            }
            if (!found)
                groups.Add(new LocationGroup().Add(lt));
        }
    
        public IEnumerator<LocationGroup> GetEnumerator() => groups.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
