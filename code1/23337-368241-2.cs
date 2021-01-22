    protected void repeaterResult_ItemDataDataBound(object sender, RepeaterItemEventArgs e)
    {
      SimpleEntity ent = e.Item.DataItem as SimpleEntity;
      Literal ltlOption = e.Item.FindControl("ltlOption") as Literal;
      if (ent != null && ltlOption != null)
      {
         if (!string.IsNullOrEmpty(ent.Option))
         {
            ltlOption.Text = ent.Option;
         }
         else
         {
            ltlOption.Text = "Not entered!";
         }
      }
    }
