        Controls.Clear();
        theContainer = new TemplatedControlContainer("Hello World");
        this.ItemTemplate.InstantiateIn(theContainer);
        Controls.Add(theContainer);
        this.DataBind();
    }
