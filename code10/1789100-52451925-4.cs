    public class RectangleGroup : IEnumerable<Rectangle> {
        List<Rectangle> members;
        Rectangle center;
    
        public RectangleGroup() {
            members = new List<Rectangle>();
        }
    
        public RectangleGroup Add(Rectangle r) {
            members.Add(r);
            center = new Rectangle("center", new Point(members.Average(m => m.Loc.X), members.Average(m => m.Loc.Y)));
            return this;
        }
    
        public bool BelongsToGroup(Rectangle r) => center.Loc.Distance(r.Loc) <= 5;
        
        public Rectangle Middle() => members.OrderBy(m => m.Loc.Distance(center.Loc)).First();
    
        public IEnumerator<Rectangle> GetEnumerator() => members.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
