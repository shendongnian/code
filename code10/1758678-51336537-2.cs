    DepartmentsConfiguration config = (DepartmentsConfiguration) ConfigurationManager
        .GetSection("departmentConfiguration");
    foreach (Department department in config.Departments)
    {
        Console.WriteLine($"{department.Id}, {department.Name}");
        foreach (Product product in department.Products)
        {
            Console.WriteLine($"{product.Name}, {product.Price}");
            foreach (string key in product.Items.AllKeys)
            {
                Console.WriteLine($"{key} -> {product.Items[key].Value}");
            }
        }
    }
