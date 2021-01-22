    class Range { 
        public Range(int x, int y) {
            X = x;
            Y = y;
        }
 
        public int X { get; set; }
        public int Y { get; set; }
    }
   
    var ranges = new List<Range>();
    ranges.Add(new Range(4199,6800));
    ranges.Add(new Range(6999,8200));
    ranges.Add(new Range(9999,10100));
    ranges.Add(new Range(10999,11100));
    ranges.Add(new Range(11999,12100));
    bool inRange = ranges.Count(r => x >= r.X && x <= r.Y) > 0;
