    public class ProductEditorPresenter
    {
        public void Initialize(IProductEditorView view, IProductBuilder productBuilder)
        {
           view.SaveProduct += delegate
                               {
                                  var product = productBuilder.Create(view.ProductId, view.ProductDescription);
                                  product.Save();
                               }
        }
    }
