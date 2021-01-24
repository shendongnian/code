    var subItems = Model.SubCategory.Where(x => x.CategoryId = item.Id);
    if(subItems.Any()) {
        <table>
            <tbody>
        foreach (var subitem in subItems) {
            //...
