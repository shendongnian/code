    public interface IRepository 
    {
       MyItem GetItem(int id);
    }
    
    public class MyNopCommerceWrapper : IRepository
    {
       public MyItem GetItem(int id)
       {
           // I have no idea what NopCommerce API looks like, so I made this up.
           var myItem = NopCommerce.GetItem(id);
    
           ModifyMyItem(myItem);
    
           return myItem;
       }
    }
