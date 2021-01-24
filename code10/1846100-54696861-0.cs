     protected void SetSelected(string selectId, string value)
     {
         var lb = Page.FindControl(selectId) as ListBox;
         if (lb != null)
         {
             var item = lb.Items.FindByValue(value)
             if(item != null)
                 item.Selected = true;
         }
     }
