    public class AttributeData
    {
        public int ProductId { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public int RowIndex { get; set; }
    }
    
    yourEnumerable.Select(x => 
         Tuple.Create(
             new AttributeData
             { 
                ProductId = x.ProductId,
                DataType = "Name",
                Value= x.Name,
                RowIndex= x.RowIndex
             },
             new AttributeData
             { 
                ProductId = x.ProductId,
                DataType = "Percent",
                Value= x.Percent,
                RowIndex= x.RowIndex
             }
          ).ToList();
