      Panel _pnlArticleHeader;
      void Item_Created(Object sender, DataListItemEventArgs e)
      {
         if (e.Item.ItemType == ListItemType.Footer)
         {
            _pnlArticleHeader =(Panel)e.Item.FindControl("pnlArticleHeader");
          }
      }
