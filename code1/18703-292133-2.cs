    public void Page_Load( object sender, EventArgs e )
    {
        HtmlContainerControl div = new HtmlGenericControl( "DIV" );
        div.innerHTML = "....whatever...";
        myContent.Controls.Clear();
        myContent.Controls.Add(div);
    }
