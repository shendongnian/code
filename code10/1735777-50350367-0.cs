    //Filepath for json file
    // this can stay here
    const string FILENAME = 
    @"C:\Users\tstra\Desktop\19456932_CSE2ICX_Assessment_3\Bin\Books.json";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // this needs stay in here, enclosed within `!Page.IsPostback()`
        if (!Page.IsPostback()) 
        {
            Catalogue catalogueInstance;
            // reading data contained in the json filepath
            string jsonText = File.ReadAllText(FILENAME);
    
            //convert objects in json file to lists
            catalogueInstance = JsonConvert.DeserializeObject<Catalogue>(jsonText);
    
            // save the current state into ViewState
            ViewState["catalogueInstance"] = catalogueInstance;
    
            ddlDelete.DataSource = catalogueInstance.books;
            ddlDelete.DataTextField = "title";
            ddlDelete.DataValueField = "id";
    
            //binding the data to Drop Down List
            ddlDelete.DataBind();
       }
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // get catalogueInstance back from ViewState before trying to use it
        Catalogue catalogueInstance = (Catalogue)ViewState["catalogueInstance"];
        int id = Int32.Parse(txtID.Text);
        Book book = catalogueInstance.books.RemoveAt(b => b.id == id);
        if (book != null)
        {
            book.title = txtTitle.Text;
            book.year = Int32.Parse(txtYear.Text);
            book.author = txtAuthor.Text;
            book.publisher = txtPublisher.Text;
            book.isbn = txtISBN.Text;    
            string jsonText = JsonConvert.SerializeObject(catalogueInstance);
            File.WriteAllText(FILENAME, jsonText);
    
            // you need to reset, and rebind the datasource again
            ddlDelete.DataSource = catalogueInstance.books;
            ddlDelete.DataTextField = "title";
            ddlDelete.DataValueField = "id";
    
            //binding the data to Drop Down List
            ddlDelete.DataBind();
        }
        txtSummary.Text = "Book ID of " + id + " has Been deleted from the 
        Catalogue" + Environment.NewLine;
    }
