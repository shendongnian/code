    public partial class Record {
        static Dictionary<int, int> depth = new Dictionary<int, int>();
        public int Depth(List<Record> dbTable) {
            int ans = 0;
    
            var working = new Queue<int>();
            var cur = this;
            do {
                if (depth.TryGetValue(cur.ID, out var curDepth)) {
                    ans += curDepth;
                    break;
                }
                else {
                    working.Enqueue(cur.ID);
                    cur = dbTable.FirstOrDefault(r => r.ChildID == cur.ID);
                    if (cur != null)
                        ++ans;
                }
            } while (cur != null);
    
            var workAns = ans;
            while (working.Count > 0) {
                var workingID = working.Dequeue();
                depth.Add(workingID, workAns);
                --workAns;
            }
    
            return ans;
        }
    }
