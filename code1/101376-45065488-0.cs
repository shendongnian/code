    using System.Linq;
    ...
    class Model {
        IEnumerable<Product> Products;
    }
    ...
    // Somewhere else in your solution,
    // assume model is an instance of the Model class
    // and that Products references a concrete generic collection
    // of Product such as, for example, a List<Product>.
    ...
    var item = model.Products.ToArray()[index];
