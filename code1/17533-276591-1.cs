     protected List<string> repeaterItemTypes
       {
          get
          {
             List<string> ret = (List<string>)ViewState["repeaterItemTypes"];
             if (ret == null)
             {
                ret = new List<string>();
                ViewState["repeaterItemTypes"] = ret;
             }
             return ret;
          }
       }
    
       protected void settingRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
       {
          string type;
          if (e.Item.DataItem != null)
          {
             // data binding mode..
             type = ((XmlNode)e.Item.DataItem).LocalName;
             int i = e.Item.ItemIndex;
             if (i == repeaterItemTypes.Count)
                repeaterItemTypes.Add(type);
             else
                repeaterItemTypes.Insert(e.Item.ItemIndex, type);
          }
          else
          {
             // restoring from ViewState
             type = repeaterItemTypes[e.Item.ItemIndex];
          }
           
          for (int i = e.Item.Controls.Count - 1; i >= 0; i--)
          {
             if (e.Item.Controls[i].ID != type) e.Item.Controls.RemoveAt(i);
          }
       }
 
