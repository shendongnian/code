    private void Form1_Load(object sender, EventArgs e)
    {
        var o = new MyClass();
        o.CustomProperties = new List<CustomProperty>()
        {
            new CustomProperty
            {
                Name ="Property1",
                DisplayName ="First Property",
                Value ="Something",
                Description = "A custom description.",
            },
            new CustomProperty{ Name="Property2", Value= 100},
            new CustomProperty{ Name="Property3", Value= Color.Red},
        };
        propertyGrid1.SelectedObject = o;
    }
