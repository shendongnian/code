    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(int id, string myTextBox, FormCollection collection) {
    
      // better
      if (myTextBox != null) {
        // do something with the string
      }
      // good
      if (collection["myTextBox"] != null) {
        string textboxvalue = collection["myTextBox"].ToString();
      }
    }
