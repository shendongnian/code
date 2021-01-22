    protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args) {
      if (tvTest.CheckedNodes.Count > 0 && tvTest.CheckedNodes.Count < 4) {
        args.IsValid = true;
      } else {
        args.IsValid = false;
      }
    }
