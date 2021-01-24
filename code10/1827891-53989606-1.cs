    var categories = dataFromDb.AsEnumerable()
        .GroupBy(_ => _.Field<string>("CategoryName"))
        .Select(g => new {
            CategoryName = g.Key,
            SubCategories = g.Select(_ => _.Field<string>("SubcategoryName"))
        });
    foreach (var category in categories) {
        var name = category.CategoryName;
        //...Create GroupBox
        var groupBox = new GroupBox() {
            Text = name
        };
        //...
        foreach (var subcategoryName in category.SubCategories) {
            //...Create CheckBbox with subcategoryName and add to groupbox
            var checkBox = new CheckBox();
            checkBox.Text = subcategoryName;
            //...
            groupBox.Controls.Add(checkBox);
        }
        //...do something with groupbox
    }
