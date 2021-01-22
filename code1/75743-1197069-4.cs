    namespace ERPBackend
    {
            interface IProduct
            {
                    string Code { get; }
                    string Description { get; }
            }
     
            class ProductForm
            {
                    public IProduct CreateProductFromInput()
                    {
                            ...
     
                            return product;
                    }
            }
    }
     
    namespace SQLBackend
    {
            interface IProduct
            {
                    string Id { get; }
                    string Description { get; }
            }
           
            class ProductDB
            {
                    public void SaveProduct(IProduct product)
                    {
                            ...
                    }
            }
    }
     
    namespace MyApplication
    {
            class ProductController
            {
                    private ProductForm form;
                    private ProductDB db;
     
                    public ProductController(ProductForm form, ProductDB db)
                    {
                            this.form = form;
                            this.db = db;
                    }
                    public void AddProduct()
                    {              
                            ERPBackend.IProduct product1 = form.CreateProductFromInput();
                            SQLBackend.IProduct product2 =
                                    new SQLBackend.MyProduct(product1.Code, product1.Description);
                            db.SaveProduct(product2);
                    }
            }
    }
