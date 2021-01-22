    // Get a list of all departments.
    IEnumerable<Department> departments = GetAllDepartments();
    // Get a list of all products.
    var products = departments.SelectMany(d => d.Products).Distinct();
    // Filter out all products that are not contained in all departments.
    var filteredProducts = products.
        Where(p => departments.All(d => d.Products.Contains(p)));
