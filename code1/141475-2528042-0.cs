    interface IPropertyBase
    {
        decimal Price { get; set; }
        int Bathrooms { get; set; }
    }
    partial class Residential : IPropertyBase
    {
    }
    partial class Commercial : IPropertyBase
    {
    }
    class Property : IPropertyBase
    {
     public decimal Price { get; set; }
     public int Bathrooms { get; set; }
        // Commercial
        public int Offices { get; set; }
        // Residential
        public int Bedrooms { get; set; }
        private void CopyFromBase(IPropertyBase o)
        {
            Price = o.Price;
            Bathrooms = o.Bathrooms;
        }
        public void CopyFrom(Commercial o)
        {
            CopyFromBase(o);
            Offices = o.Offices;
        }
        public void CopyFrom(Residential o)
        {
            CopyFromBase(o);
            Bedrooms = o.Bedrooms;
        }
    }
As a general note, "union" objects of this type are often a bad idea. You're better off defining the common properties in an IPropertyBase interface and leaving the Residential/Commercial objects in their "native" form as you work with them. If you need to create a combined collection of all properties in an area, for example, create a List&lt;IPropertyBase&gt; and work directly with that -- it will keep the objects in the list intact (allowing you to determine their original type later using the is/as operators if you need) and it won't have the overhead of lots of empty, meaningless fields on each object.
