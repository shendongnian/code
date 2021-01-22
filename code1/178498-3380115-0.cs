      public class Item {
         public int Id;
         public string Desc;
      }
      public class DBDataContext {
         public System.Collections.Generic.List<Item> Items {
            get {
               var items = new System.Collections.Generic.List<Item> {
                  new Item {
                     Desc = null,
                     Id = 1
                  }
               };
               return items;
            }
         }
      }
      public class busItem {
         public Item vItem;
         public busItem(int pItem_Id) {
            DBDataContext db = new DBDataContext();
            Item vItemQuery = (from i in db.Items
                               where i.Id == pItem_Id
                               select i).FirstOrDefault();
            vItem = new Item();
            vItem.Id = vItemQuery.Id;
            vItem.Desc = vItemQuery.Desc;
         }
      }
      [Test]
      public void TestBusItem() {
         busItem item = new busItem(1);
         item.vItem.Desc = "new description";
      }
