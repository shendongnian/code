    public interface ISecureEntity {
     Func<T,bool> SecureFunction<T>(UserAccount user);
    }
    public class Product : ISecureEntity {
     public Expression<Func<T,bool>> SecureFunction<T>(UserAccount user) {
      return SecureFunction(user) as Expression<Func<T,bool>>; 
     }
     public static Expression<Func<Product,bool>> SecureFunction(UserAccount user) {
      return f => f.OwnerId==user.AccountId;
     }
     public string Name { get;set; }
     public string OwnerId { get;set; }
    }
    public class ProductDetail : ISecureEntity {
     public Expression<Func<T,bool>> SecureFunction<T>(UserAccount user) {
      return SecureFunction(user) as Expression<Func<T,bool>>; 
     }
     public static Func<ProductDetail,bool> SecureFunction(UserAccount user) {
      return pd => Product.SecureFunction(user).Invoke(pd.ParentProduct);
     }
     public int DetailId { get;set; }
     public string DetailText { get;set; }
     public Product ParentProduct { get;set; }
    }
