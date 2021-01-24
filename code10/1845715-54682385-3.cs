    public List<TreeNode> Nodes
    {
        get
        {
            if (HttpContext.Current.Session["Nodes"] == null)
            {
                HttpContext.Current.Session["Nodes"] = new List<TreeNode>();
            }
            return HttpContext.Current.Session["Nodes"] as List<TreeNode>;
        }
        set
        {
            HttpContext.Current.Session["Nodes"] = value;
        }
    }
