    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            var repo = new DataRepository<Client, ApplicationDbContext>();
    
            var selectedCategory = GetDropDownListSelection<Category>(CategoryList);
            var selectedSubcategory = GetDropDownListSelection<Category>(SubcategoryList);
            var name = NameTextBox.Text;
    
            var client = new Client
            {
                Name = name,
                // either
                Category = new DataRepository<Category , ApplicationDbContext>().GetSingleItem(selectedCategory.id),
                // or, easier (assuming you have FK properties defined on the model)
                CategoryId = selectedCategory.Id,
                // repeat as needed
                Subcategory = selectedSubcategory
            };
    
            repo.AddItem(client);
        }
        // Error handling things
    }
