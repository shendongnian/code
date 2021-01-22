    [TestMethod]
    public void CanMapItem()
    {
    	new PersistenceSpecification<Item>(Session, new CustomIEqualityComparer())
    		.CheckProperty(i => i.Title, "Test item")
    		.CheckProperty(i => i.Description, "Test description")
    		.CheckProperty(i => i.SalesPrice, (decimal)0.0)
    		.CheckList(i => i.ItemPictures, _itemPictures) // Complains that Item on ItemPicture is null.
    		.VerifyTheMappings();
    }
    
    
    public class CustomIEqualityComparer: IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x is ItemPicture && y is ItemPicture)
            {
                return ((ItemPicture) x).Id == ((ItemPicture) y).Id;
            }
            if(x is DateTime && y is DateTime)
            {
    			return ((DateTime)x).Year ==((DateTime)y).Year;
            }
            return x.Equals(y);
        }
     
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
