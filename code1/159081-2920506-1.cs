      void R1_ItemDataBound(Object sender, DataGridItemEventArgs e)
      {
          if (e.Item.ItemType == ListItemType.Item || 
              e.Item.ItemType == ListItemType.AlternatingItem) 
             {
                 if(e.Item.Cells[0].Text.Length <= 40){
                     e.Item.Cells[0].Text = String.Empty;
                 }
             }
      }
