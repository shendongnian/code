    <asp:LinkButton runat="server" ID="next_page" Text="Next Page" OnClick="NextPage_Click" />
...
    void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData(0);
        }
    }
    void LoadData(int page)
    {
        //pull page of data from twitter & show on page
        next_page.CommandArgument = (page+1).ToString();
    }
    void NextPage_Click(object sender, EventArgs e)
    {
        int page = int.Parse(((LinkButton)sender).CommandArgument);
        LoadData(page);
    }
