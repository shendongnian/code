    public class ProductList : List<Product> {
        public void update(Product product, int nrOfDuplications, int newQuantity) {
           Remove(product);
           for(int i = 0; i < nrOfDuplications; i++) {
               Add(new Product() {
                   ref = product.ref,
                   article = product.article,
                   quantity = newQuantity
               });
           }
        }
    }
