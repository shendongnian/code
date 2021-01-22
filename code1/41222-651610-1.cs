    protected void Page_Load(object sender, EventArgs e) 
    { 
      if (Page.IsPostBack)
      { 
        string pathToNode = (string)Session("SelPath"); 
        Session.Remove("SelPath"); 
        TreeNode selNode = TreeView1.FindNode(pathToNode); 
        if (selNode != null) 
        { 
          selNode.Expand(); 
        } 
      } 
    } 
