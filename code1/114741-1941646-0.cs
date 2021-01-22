    protected override CreateChildControls()
    {
      // .. creation of updatepanel, say upd1
      Panel container = new Panel{CssClass = "webpartContainer"};
      upd1.ContentTemplateContainer.Controls.Add(container);
      container.Controls.Add(dropdown1); // etc. etc.
    }
