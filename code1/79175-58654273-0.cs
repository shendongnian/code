           public class ProductList
           {
             public string product{get;set;}
             public List<ProductList> objList{get;set;}
           }
    
    ProductListobj=new ProductList();
    obj.objList=new List<ProductList>();
    obj.objList.add(new ProductList{product="Football"});
