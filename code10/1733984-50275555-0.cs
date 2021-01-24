    public class BaseModel<T>
    { 
        public int ProductId {get;set;}
        public T ModelObject { get; set; } 
    }
    // ...
    BaseModel<ProductType1> baseModel = new BaseModel<ProductType1>(); 
    // ...
    @model Project1.Models.BaseModel<ProductType1>
