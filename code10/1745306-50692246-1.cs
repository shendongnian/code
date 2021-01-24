    List<Book> bookList = new List<Book>();
    for(int i = 0; i < 3; i++)
    {
        //for simplicity of solution, i have used cover as string not image,
        // you can perform same logic with cover as image too.
        bookList.Add(new Book(i, "title" + i, "publisher" + i, "auther" + i, "cover" + i));
    }
    DataTable dt = new DataTable();
    dt.Columns.Add("ColBook");
    dt.Columns.Add("ColData");
    foreach(Book book in bookList)
    {
        DataRow dr = dt.NewRow();
        dr["ColBook"] = book.BookCoverImage;
        dr["ColData"] = "Title:"+book.Title + "\nPublisher:" + book.Publisher + "\nAuthor:" + book.Author;
        dt.Rows.Add(dr);
    }
    dataGridView1.DataSource = dt;
    dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
