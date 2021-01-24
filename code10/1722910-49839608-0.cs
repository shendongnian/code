    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //'" + ItemTextBox.Text + "','" + BrandTextBox.Text + "','" + CostTextBox.Text + "','" + PriceTextBox.Text + "'" + ColourTextBox.Text + "'" + SizeTextBox.Text + "'" + QuantityTextBox.Text + ")", con
        con.Open();
        string sqlquery = "insert into [Project_X_Or] (Item,Brand,Cost,Price,Colour,Size,Quantity) values (@Item,@Brand,@Cost,@Price,@Colour,@Size,@Quantity)";
        SqlCommand command = new SqlCommand(sqlquery, con);
        //Item Name**********
        string Item = ItemTextBox.Text;
        command.Parameters.AddWithValue("Item", Item);
        //Brand Of Product**********
        string Brand = BrandTextBox.Text;
        command.Parameters.AddWithValue("Brand", Brand);
        //Cost Of Item From Supplier**********
        string Cost = CostTextBox.Text;
        command.Parameters.AddWithValue("Cost", Cost);
        //Price Of Item When Sold With Design**********
        string Price = PriceTextBox.Text;
        command.Parameters.AddWithValue("Price", Price);
        //Colour Of Product**********
        string Colour = ColourTextBox.Text;
        command.Parameters.AddWithValue("Colour", Colour);
        //Size of Product (T-Shirts, Hoodies)**********
        string Size = SizeTextBox.Text;
        command.Parameters.AddWithValue("Size", Size);
        //Quantity Of Product In Stock**********
        string Quantity = QuantityTextBox.Text;
        command.Parameters.AddWithValue("Quantity", Quantity);
        command.ExecuteNonQuery();
        con.Close();
        string result = "Added  " + Item + " " + Brand + " " + Cost + " " + Cost + " " + Price + " " + Colour + " " + Size + " " + Quantity;
        resultLabel.Text = result;
        if (string.IsNullOrEmpty(ItemTextBox.Text))
        {
            resultLabel.Text=("Enter Item Into Item Field");
        }
        if (string.IsNullOrEmpty(QuantityTextBox.Text))
        {
            resultLabel.Text = ("Enter Amount Into Quantity Field");
        }
        //if (string.IsNullOrEmpty(""))
        //    {
        //    resultLabel2.Text = ("Please Fill Out Fields Above");
        //}
        ItemTextBox.Text = string.Empty;
        BrandTextBox.Text = string.Empty;
        CostTextBox.Text = string.Empty;
        PriceTextBox.Text = string.Empty;
        ColourTextBox.Text = string.Empty;
        SizeTextBox.Text = string.Empty;
        QuantityTextBox.Text = string.Empty;
    }
