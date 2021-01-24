    public string GetLastLeafLeft(string Id)
        {
            var leftchildId = dbcontext.NMTrees.Where(ll => ll.UserID == Id).Select(tt => tt.LeftChildID).FirstOrDefault();
            return leftchildId;
        }
