    IFilmRepository _filmRepository;
    
    public void Page_Load (object sender, EventArgs e)
    {
        _filmRepository = new MySqlFilmRepository(ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
    }
    
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = _filmRepository.SearchFilmsByTitle(SearchTextBox.Text);
    	dataGridView2.DataSource = _filmRepository.GetActorsForFilm(SearchTextBox.Text);
    }
