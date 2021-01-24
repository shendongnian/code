    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBox1.Items.Add("B");
            ListBox1.Items.Add("A");
            ListBox1.Items.Add("P");
            ListBox1.Items.Add("X");
            ListBox1.Items.Add("F");
            ListBox1.Items.Add("S");
            ListBox1.Items.Add("Z");
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String txt=txtsearch.Text;
        if (ListBox1.Items.FindByText(txt)!= null)
        {
           // ListBox1.Items.FindByText(txt).Selected = true;
            Response.Write("<script> alert('Item found.');</script>");
        }
        else
        {
            Response.Write("<script> alert('Item Not found.');</script>");
        }
    }
    
}
