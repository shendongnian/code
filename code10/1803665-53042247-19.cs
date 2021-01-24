    public void fillPrevNodes()
    {
        foreach (var n in theNodes)
        {
            var pn = n.prevNodeNames.Split(',');
            foreach (var p in pn)
            {
                var hit = theNodes.Where(x => x.Text == p);
                if (hit.Count() == 1) n.prevNodes.Add(hit.First());
                else if (hit.Count() == 0) startNodes.Add(n);
                else Console.WriteLine(n.Text + ": prevNodeName '" + p + 
                                                "' not found or not unique!" );
            }
        }
    }
