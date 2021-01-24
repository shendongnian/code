    public class LocationGroup : IEnumerable<Rectangle> {
        List<Rectangle> members;
        Rectangle center;
    
        public LocationGroup() {
            members = new List<Rectangle>();
        }
    
        public LocationGroup Add(Rectangle lt) {
            members.Add(lt);
            center = new Rectangle("center", new Point(members.Average(m => m.Loc.X), members.Average(m => m.Loc.Y)));
            return this;
        }
    
        public bool BelongsToGroup(Rectangle lt) => center.Loc.Distance(lt.Loc) <= 5;
        
        public Rectangle Middle() => members.OrderBy(m => m.Loc.Distance(center.Loc)).First();
    
        public IEnumerator<Rectangle> GetEnumerator() => members.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
