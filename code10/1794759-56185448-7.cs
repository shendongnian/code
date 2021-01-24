    public void RemoveTwins(ref BreadthFirst bf1, ref BreadthFirst bf2) {
        JsonNode traversal = bf1.Next();
        Boolean removed = false;
        do {
            if (!removed) {
                if (bf2.Current != null) while (bf1.Level == bf2.Level && bf2.Next() != null) ;
                if (bf2.Current != null) while (bf1.Level != bf2.Level && bf2.Next() != null) ;
                else bf2.Current = bf2.root;
            }
            else traversal = bf1.Next();
            if (bf2.Level < 0) bf2.Current = bf2.Root;
            do {
                removed = bf1.NextAs(bf1.src, bf2, bf2.src);
                if (removed && bf1.Orphan && bf2.Orphan) {
                    JsonNode same = bf1.Current.Parent;
                    traversal = bf1.RemoveCurrent();
                    same = bf2.Current.Parent;
                    bf2.RemoveCurrent();
                    bf1.UpdateLevel();
                    bf2.UpdateLevel();
                    if (traversal == null
                    || bf1.Root == null || bf2.Root == null
                    || (bf1.Level == 0 && bf1.Current.NodeBelow == null)) {
                        traversal = null;
                        break;
                    }
                } else
                if (!removed) {
                    break; 
                } else removed = false;
            } while (removed);
            if (!removed) traversal = bf1.Next();
        } while (traversal != null);
    }
