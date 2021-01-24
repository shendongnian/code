    public void RemoveDuplicates(ref BrowseNode v1, ref BrowseNode v2)
    {
        BreadthFirst bf1 = new BreadthFirst(v1);
        BreadthFirst bf2 = new BreadthFirst(v2);
        BrowseNode traversal = bf1.Root;
        bf2.NextAs(bf1);
        Boolean removed = true;
        do
        {
            if (!removed)
            {
                if (bf2.Current != null) while (bf1.Level == bf2.Level && bf2.Next() != null) ;
                if (bf2.Current != null) while (bf1.Level != bf2.Level && bf2.Next() != null) ;
                else bf2.Current = bf2.Root;
            }
            else traversal = bf1.Next();
            if (bf2.Level < 0) bf2.Current = bf2.Root;
            do
            {
                removed = bf1.NextAs(bf2);
                if (removed && bf1.Orphan && bf2.Orphan)
                {
                    traversal = bf1.RemoveCurrent();
                    bf2.RemoveCurrent();
                    if (traversal == null) break;
                }
                else removed = false;
            } while (removed);
            if (!removed) traversal = bf1.Next();
        } while (traversal != null);
    }
