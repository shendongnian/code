    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable dataFromDb = GetData();
        // extract distinct categories into an array - for each group box
        string[] distinctCetgories = dataFromDb.AsEnumerable()
            .Select(x => x.Field<string>("CategoryName")).Distinct().ToArray();
        
        // itterate on the distinct categories
        foreach(var itm in distinctCetgories)
        {
            // extract all the subcategories for the checkboxes inside the groupbox
            string[] subcategories = dataFromDb.AsEnumerable().
                Where(x => x.Field<string>("SubCategoryName") == itm).
                Select(y => y.Field<string>("SubCategoryName")).ToArray();
    
            flowLayoutPanel1.Controls.Add(GetGroupBox(itm,subcategories, 200, 100));
        }
    }
    
    private GroupBox GetGroupBox(string categoryName,string[] subCategories,int width, int 
    {
        GroupBox g = new GroupBox();
        g.Size = new Size(width, height);
        g.Text = categoryName;
    
        var y = 20;
        foreach (var itm in subCategories)
        {
            CheckBox cb = new CheckBox();
            cb.Text = itm;
            cb.Location = new Point(5, y);
            // you can add an event here...
            cb.CheckedChanged += cb_SomeEvent;
            g.Controls.Add(cb);
            y += 20;
        }
    
        return g;
    }
    
    private void cb_SomeEvent(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private DataTable GetData()
    {
        // return you datadata using your query:
        // SELECT* FROM Category AS c
        // INNER JOIN Product AS P ON C.CategoryId = P.CategoryId
        // ..... create datatable ......
        return new DataTable();
    }
