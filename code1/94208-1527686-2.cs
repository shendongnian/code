    protected override void Render(HtmlTextWriter writer)
    {
        base.Render(writer);
    
        this.ProcessMassiveWorkLoad();
    }
    private void ProcessMassiveWorkLoad()
    {
        for(int i = 0; i < 100000; i++)
        {
            // Do some work
            
            // Write the fact you have work
            Response.Write(string.Format("Done {0} of 100000", i);
        }
    }
