     public interface IRepository<T>{
        void Insert(T item);
     }
     public class AuctionItem : IRepository<IAuctionItem> {
       public void Insert(IAuctionItem item) {
          _dataStore.DataContext.AuctionItems.InsertOnSubmit((AuctionItem)item);
          _dataStore.DataContext.SubmitChanges();
       }
     }
