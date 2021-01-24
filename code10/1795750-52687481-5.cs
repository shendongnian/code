    public class DataHelper : IDataHelper {
        private readonly IHttpContextAccessor accessor;
        public DataHelper(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        public List<Data> GetData() {
            List<Data> data = accessor.HttpContext.Session.Get<List<Data>>("Data");
            if (data == null) {
                data = new List<Data>();
                data.Add(new Data { ID = 1, ParentID = 0, Title = "Root" });
                data.Add(new Data { ID = 2, ParentID = 1, Title = "A" });
                data.Add(new Data { ID = 3, ParentID = 1, Title = "B" });
                data.Add(new Data { ID = 4, ParentID = 1, Title = "C" });
                data.Add(new Data { ID = 5, ParentID = 2, Title = "A1" });
                data.Add(new Data { ID = 6, ParentID = 2, Title = "A2" });
                data.Add(new Data { ID = 7, ParentID = 2, Title = "A3" });
                data.Add(new Data { ID = 8, ParentID = 3, Title = "B1" });
                data.Add(new Data { ID = 9, ParentID = 3, Title = "B2" });
                data.Add(new Data { ID = 10, ParentID = 4, Title = "C1" });
                data.Add(new Data { ID = 11, ParentID = 8, Title = "B1A" });
                data.Add(new Data { ID = 12, ParentID = 8, Title = "B1B" });
                accessor.HttpContext.Session.Set("Data", data);
            }
            return data;
        }
        public void MoveNodes(int[] nodeKeys, int parentID) {
            var data = GetData();
            var processedNodes = data.Join(nodeKeys, x => x.ID, y => y, (x, y) => x);
            foreach(var node in processedNodes) {
                if (processedNodes.Where(x => x.ID == node.ParentID).Count() == 0) {
                    if (node.ParentID == 0) {
                        MakeParentNodeRoot(parentID);
                    }
                    node.ParentID = parentID;
                }
            }
        }
        public void MoveNode(int nodeID, int parentID) {
            var data = GetData();
            var node = data.Find(x => x.ID == nodeID);
            if (node.ParentID == 0) {
                MakeParentNodeRoot(parentID);
            }
            node.ParentID = parentID;
        }
        public void MakeParentNodeRoot(int id) {
            GetData().Find(x => x.ID == id).ParentID = 0;
        }
    }
