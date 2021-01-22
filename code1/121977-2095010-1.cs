    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
         if (e.Item is GridDataItem)
         {
              GridDataItem dataBoundItem = e.Item as GridDataItem;
              CustomObject o = e.Item.DataItem as CustomObject;
    
              if(o.Description.Length > 50)
              {
                   dataBoundItem["Description"].Text = o.Description.Substring(0, 47) + "..."
              }
          }
    }
