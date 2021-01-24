    public partial class Record {
        static Dictionary<int, int> depth = new Dictionary<int, int>();
        public int Depth(List<Record> dbTable) {
            int ans = 0;
    
            var cur = this;
            do {
                if (depth.TryGetValue(cur.ID, out var curDepth)) {
                    ans += curDepth;
                    break;
                }
                else {
                    cur = dbTable.FirstOrDefault(r => r.ChildID == cur.ID);
                    if (cur != null)
                        ++ans;
                }
            } while (cur != null);
    
            depth.Add(ID, ans);
            return ans;
        }
    }
