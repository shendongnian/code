    List<string> allowedControls = new List<string> { "Control1", "Control3" };
    IEnumerable<Control> controlsWithoutViewState = Page.Controls.Where(c => !allowedControls.Contains(c.ID));
    foreach(Control c controlsWithoutViewState){
      if(c is WebControl) ((WebControl)c).EnableViewState = false;
    }
