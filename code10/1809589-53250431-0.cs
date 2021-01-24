    public interface ICatalogDataEntryForm<out T> 
    { }
    
    public interface ICatalogDataGridForm<out T> 
    { }
    
    public class CatalogDataEntryForm<T> : ICatalogDataEntryForm<T>
    { }
    public class CatalogDataGridForm<T> : ICatalogDataGridForm<T>
    {}
    
