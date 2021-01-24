    public void RemoveTwins(ref BreadthFirst bf1, ref BreadthFirst bf2)
    {
        Printer prn = new Printer();
        int debug = 0;
        JsonNode traversal = bf1.Next();
        Boolean removed = false;
        int removeNo = 0;
        do
        {
            if (!removed)
            {
                if (bf2.Current != null) while (bf1.Level == bf2.Level && bf2.Next() != null) ;
                if (bf2.Current != null) while (bf1.Level != bf2.Level && bf2.Next() != null) ;
                else bf2.Current = bf2.root;
            }
            else traversal = bf1.Next();
            if (bf2.Level < 0) bf2.Current = bf2.Root;
            do
            {
                removed = bf1.NextAs(bf1.src, bf2, bf2.src);
                if (removed && bf1.Orphan && bf2.Orphan)
                {
                    removeNo++;
                    JsonNode same = bf1.Current.Parent;
                    if (debug == 2) {
                        String log = prn.Print(ref same, bf1.src, 0, true).ToString();
                        if (log.Length > 200) log = log.Substring(0, 200);
                        Console.Write($"1> {log}\nRemoving:{bf1.Current.debugView(bf1.src)}\n");
                    }
                    if (debug == 1) Console.Write($"1> Removing:{bf1}\n");
                    traversal = bf1.RemoveCurrent();
                    same = bf2.Current.Parent;
                    if (debug == 2) {
                        String log = prn.Print(ref same, bf2.src, 0, true).ToString();
                        if (log.Length > 200) log = log.Substring(0, 200);
                        Console.Write($"1> {log}\nRemoving:{bf2.Current.debugView(bf2.src)}\n");
                    }
                    if (debug == 1) Console.Write($"2> Removing:{bf2}\n");
                    bf2.RemoveCurrent();
                    if (debug == 2) Console.Write($"2< {prn.Print(ref same, bf2.src, 0, true).ToString()}**\n");
                    bf1.UpdateLevel();
                    bf2.UpdateLevel();
                    if (traversal == null
                    || bf1.Root == null
                    || bf2.Root == null
                    || (bf1.Level == 0 && bf1.Current.NodeBelow == null))
                    {
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
