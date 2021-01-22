    ItemData oid = (ItemData)c;
    CheckBox chkSel = (CheckBox)oid.FindControl("chkSelected");
    if(chkSel != null) {
          if(chkSel.Checked) {
             Literal litId = (Literal)oid.FindControl("litId");
             itemsToDelete.Add(Utils.GetIntegerOnly(litId.Text));
          }
    }
