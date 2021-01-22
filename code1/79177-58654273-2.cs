public class ProductList
{
   public string product{get;set;}
   public List<ProductList> objList{get;set;}
}
   
ProductList obj=new ProductList();
obj.objList=new List<ProductList>();
obj.objList.add(new ProductList{product="Football"});
now assign obj to session
Session["Product"]=obj;
for retrieval of session.
ProductList objLst = (ProductList)Session["Product"];
