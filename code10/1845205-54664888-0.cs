    private void PopulateMenu(DataTable dt, string Lvl4, MenuItem parentMenuItem)
    {
      string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
      foreach (DataRow row in dt.Rows)
      {
        string url = Convert.ToString(row["fullPath"]);
        url = url.Replace(">", "/");
        HtmlGenericControl h3 = new HtmlGenericControl("h3");
        HtmlGenericControl li = new HtmlGenericControl("li");
        HtmlGenericControl div = new HtmlGenericControl("div");
        HtmlGenericControl anchor = new HtmlGenericControl("a");
        // >>> Instead of generating a new ul for every row, only generate it if you add a new header
        HtmlGenericControl ul;
       //This are the expression to produce the value to be compare with the ID of the menu to see whether they will be parent or child menu item.
       string ComparePageID = row["PageID"].ToString();
       string CompareLvl3 = "0000";
       string CompareLvl4 = CompareLvl3.Replace("0000", "");
       if (ComparePageID.Contains(CompareLvl3))
       {
         h3.InnerText = row["Description"].ToString();
         //I tried to use the session to save the ul id like  
         //Session["sidemenu"] = row["PageID"];
         // >>> Create new ul only if header is created
         ul = new HtmlGenericControl("ul");
         ul.Attributes.Add("id", row["PageID"].ToString());
         ul.Attributes.Add("runat", "server");
         div.Attributes.Add("id", "server");
         div.Attributes.Add("runat", "server");
         accordion.Controls.Add(h3);
         accordion.Controls.Add(div);
         div.Controls.Add(ul);
       }
       else
       {
         anchor.Attributes.Add("href", "~/html/" + url + ".aspx");
         anchor.Attributes.Add("id", row["PageID"].ToString());
         anchor.Attributes.Add("target", "manualmain");
         anchor.Attributes.Add("runat", "server");
         anchor.InnerText = row["Description"].ToString();
         li.Controls.Add(anchor);
         //But when I use the value of Session["sidemenu"] at here to add the child item in li, error "the XXX does not exist in the current context" occurred
         // >>> Add li to ul
         ul.Controls.Add(li);
       }
     }
