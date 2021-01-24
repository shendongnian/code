    public class SomeClass
    {  
       [RegularExpression("^[0-9]*$", ErrorMessage = "Receive Quantity can only contain number")]
       public decimal? receive_quantity { get; set; }
    
       [RegularExpression("^[0-9]*$", ErrorMessage = "Damaged Quantity can only contain number")]
       public decimal? damaged_quantity { get; set; }  
       public bool IsSelected { get; set; }    
       public string item_name { get; set; }
    } 
