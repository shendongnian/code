    protected override void OnLoad(EventArge e)
     { base.OnLoad(e);
       EnsureChildControls();
       
       var linkButtons = from c in AfterPageRepeater.Controls
                                                    .Cast<Control>()
                                                    .OfType<RepeaterItem>()
                         where c.HasControls()
                         select c into ris
                            from lb in ris.OfType<LinkButton>()
                            select lb;
       foreach(var linkButton in linkButtons)
        { linkButton.Click += PageNavigateButton_Click
        }                          
     }
