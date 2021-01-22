    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!Page.IsPostBack)
        { 
           // Make table 1 and table 2 visible
           // Hide table 3         
        }
    }
    Update1_Click(object sender, eventargs e)
    {
        PromoCode();
    }
    Update2_Click(object sender, eventargs e)
    {
        Recalculate();
    }
    Next_Click(object sender, eventargs e)
    {
        // Hide table 1 and 2
        // Make table 3 visible
    }
