    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //bind the initial items to the listview
            products.DataSource = getData(0);
            products.DataBind();
            //store the current page number in a viewstate
            ViewState["currentPage"] = 0;
        }
    }
    public List<int> getData(int pageIndex)
    {
        //the numver of items on a page
        int itemsPerPage = 30;
        //create a new list
        List<int> list = new List<int>();
        //add some dummy data
        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }
        //return the list with the correct number of items and offset
        return list.Skip(pageIndex * itemsPerPage).Take(itemsPerPage).ToList();
    }
    protected void btnLoadMore_Click(object sender, EventArgs e)
    {
        int currentPage = 0;
        //always check if the viewstate exists
        if (ViewState["currentPage"] != null)
        {
            //convert the viewstate back to an int and increment
            currentPage = Convert.ToInt32(ViewState["currentPage"]) + 1;
        }
        //bind the new items to the listview
        products.DataSource = getData(currentPage);
        products.DataBind();
        //update the page number in a viewstate
        ViewState["currentPage"] = currentPage;
    }
