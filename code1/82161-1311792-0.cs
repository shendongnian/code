    public TextBox[,] tx
    {
       get { return ViewState["tx"] as TextBox[,]; }
       set { ViewState["tx"] = tx; }
    }
