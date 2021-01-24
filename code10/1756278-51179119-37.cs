    treeView1.Nodes.Clear();
    TreeNode cn = new TreeNode("rtf tree"); // a root node
    cn = cn.Nodes.Add("");                  // first node
    for (int i = 1; i < rawRtf.Length; i++)
    {
        char p = rawRtf.Text[i - 1];
        char c = rawRtf.Text[i];
        // always watch for escaped curlies (but ignoring escaped blackslashes)
        // either closing or opening else real character:
        if (c=='}' && p != '\\') cn = cn.Parent;
        else if (c== '{' && p != '\\') cn = cn.Nodes.Add("");
        else cn.Text += c;
    }
     treeView1.Nodes.Add(cn);
