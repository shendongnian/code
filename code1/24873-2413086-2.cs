     KeyValuePair<string, List<scenarioItem>> myData = (KeyValuePair<string, List<scenarioItem>>)(((System.Web.UI.WebControls.ListViewDataItem)(e.Item)).DataItem);
        Repeater repeater = (Repeater)e.Item.FindControl("childData");
        repeater.HeaderTemplate = new MyTemplate(ListItemType.Header);
        repeater.ItemTemplate = new MyTemplate(ListItemType.Item);
        repeater.AlternatingItemTemplate =
           new MyTemplate(ListItemType.AlternatingItem);
        repeater.FooterTemplate = new MyTemplate(ListItemType.Footer);
        repeater.DataSource = myData.Value;
        repeater.DataBind();
   
    public class MyTemplate : System.Web.UI.ITemplate
{
    System.Web.UI.WebControls.ListItemType templateType;
    public MyTemplate(System.Web.UI.WebControls.ListItemType type)
    {
        templateType = type;
    }
    static void Item_DataBinding(object sender, System.EventArgs e)
    {
        PlaceHolder ph = (PlaceHolder)sender;
        RepeaterItem ri = (RepeaterItem)ph.NamingContainer;
        scenarioItem myDataItem = (scenarioItem)ri.DataItem;
        if (ri.ItemIndex == 0) { 
            //create the header column part once
            //Add ScenarioName
            ph.Controls.Add(new LiteralControl("<tr><td>ScenarioName</td>"));
            //Add group concentration part
            foreach (recGroupConcItem concItem in myDataItem.mGroupConcList)
            {
                ph.Controls.Add(new LiteralControl("<td>" + concItem.groupName + @"</td>"));
            }
            ph.Controls.Add(new LiteralControl("</tr>"));
        
        }
        //Add ScenarioName
        ph.Controls.Add(new LiteralControl("<tr><td>"+myDataItem.scenarioName+@"</td>"));
        //Add group concentration part
        foreach (recGroupConcItem concItem in myDataItem.mGroupConcList) {
            ph.Controls.Add(new LiteralControl("<td>" + concItem.groupConc.ToString() + @"</td>"));
        }
        ph.Controls.Add(new LiteralControl("</tr>"));
    }
    static void ItemAlt_DataBinding(object sender, System.EventArgs e)
    {
        PlaceHolder ph = (PlaceHolder)sender;
        RepeaterItem ri = (RepeaterItem)ph.NamingContainer;
        scenarioItem myDataItem = (scenarioItem)ri.DataItem;
        //Add ScenarioName
        ph.Controls.Add(new LiteralControl("<tr bgcolor=\"lightblue\"><td>" + myDataItem.scenarioName + @"</td>"));
        //Add group concentration part
        foreach (recGroupConcItem concItem in myDataItem.mGroupConcList)
        {
            ph.Controls.Add(new LiteralControl("<td>" + concItem.groupConc.ToString() + @"</td>"));
        }
        ph.Controls.Add(new LiteralControl("</tr>"));
    }
    static void ItemHeader_DataBinding(object sender, System.EventArgs e)
    {
        PlaceHolder ph = (PlaceHolder)sender;
        RepeaterItem ri = (RepeaterItem)ph.NamingContainer;
        scenarioItem myDataItem = (scenarioItem)ri.DataItem;
   
        //Add ScenarioName
        ph.Controls.Add(new LiteralControl("<tr><td>ScenarioName</td>"));
        //Add group concentration part
        foreach (recGroupConcItem concItem in myDataItem.mGroupConcList)
        {
            ph.Controls.Add(new LiteralControl("<td>" + concItem.groupName + @"</td>"));
        }
        ph.Controls.Add(new LiteralControl("</tr>"));
    }
    public void InstantiateIn(System.Web.UI.Control container)
    {
        PlaceHolder ph = new PlaceHolder();
        Label item1 = new Label();
        Label item2 = new Label();
        item1.ID = "item1";
        item2.ID = "item2";
        switch (templateType)
        {
            case ListItemType.Header:
                ph.Controls.Add(new LiteralControl("<table border=\"1\">"));
                //    "<tr><td><b>ScenarioName</b></td>" +
                //    "<td><b>Group1</b></td> <td><b>Group2</b></td> <td><b>Group3</b></td> <td><b>Group4</b></td> </tr>"));
                //ph.DataBinding += new EventHandler(ItemHeader_DataBinding);
                break;
            case ListItemType.Item:
                ph.DataBinding += new EventHandler(Item_DataBinding);
                break;
            case ListItemType.AlternatingItem:
                ph.DataBinding += new EventHandler(ItemAlt_DataBinding);
                break;
            case ListItemType.Footer:
                ph.Controls.Add(new LiteralControl("</table>"));
                break;
        }
        container.Controls.Add(ph);
    }
