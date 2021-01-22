    protected override void OnInit(EventArgs e)
    {  
        base.OnInit(e);
        TextBox test = new TextBox();
        test.SkinkId = "MySkin";
        test.ApplyStyleSheetSkin(this); // <--
        placeHolder.Controls.Add(test);
    }
