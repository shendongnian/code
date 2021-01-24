    protected void FreezeButton(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        sb.Append("function validate() { ")
        // script content here, skipped for brevity
        sb.Append("}");
    
        // use RegisterClientScriptBlock to attach script content into <script> tag inside page body
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Example", sb.ToString(), true);
    
        // handle client-side event click if the button is a server control
        btnAdd.OnClientClick = "validate()";
    }
