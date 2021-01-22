    // Given some example data:
    var items = new[] 
    {
       new Foo() 
       {
          Id = 1,
          ParentId = -1, // Indicates no parent
          Position = 0
       },
       new Foo() 
       {
          Id = 2,
          ParentId = 1,
          Position = 0
       },
       new Foo() 
       {
          Id = 3,
          ParentId = 1,
          Position = 1
       }
    };
    
    // Turn it into a hierarchy! 
    // We'll get back a list of Node<T> containing the root nodes.
    // Each node will have a list of child nodes.
    var hierarchy = items.Hierarchize(
        -1, // The "root level" key. We're using -1 to indicate root level.
        f => f.Id, // The ID property on your object
        f => f.ParentId, // The property on your object that points to its parent
        f => f.Position, // The property on your object that specifies the order within its parent
        );
