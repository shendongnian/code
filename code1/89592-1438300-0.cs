    class ExtendedInfo
    {
        string NavigateUrl;
        string ImageUrl;
        int UniqueId;
   
        // other custom properties go here
    }
    // ...
    void CreateTreeNode ()
    {
        TreeNode TN = new TreeNode();
        string parent = "parent";    
        TN.Text = "<span class='Node'>" + doc.Title + "</span>";
        TN.Value = doc.ID.ToString();
        TN.ToolTip = doc.Title;
        ExtendedInfo extInfo = new ExtendedInfo;
        extInfo.NavigateUrl = "ViewDocument.aspx?id=" + doc.ID + "&doc=general&p=" + parent;
        extInfo.ImageUrl = "Graphics/algDoc.png";
        extInfo.UniqueId = counter;
        TN.Tag = extInfo;
    }
    // ...
    ExtendedInfo GetExtendedInfo (TreeNode node)
    {
        return node.Tag as ExtendedInfo;
    }
