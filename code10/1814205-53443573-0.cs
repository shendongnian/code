     public class ProductDetails : IComparable
        {
            public int ProductId { get; set; }
            public int CompareTo(object obj)
            {
                ProductDetails prodDetails = obj as ProductDetails;
                if (obj == null) return 1;
    
                if (prodDetails != null)
                {
                    if (this.ProductId < prodDetails.ProductId) return 1;
                    else
                        return 0;
    
                }
                else {
                    return 0;
                }
    
            }
        }
