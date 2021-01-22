    public class CategoryObjCollection:List<CategoryObj>
    {
       public CategoryObjCollection(IEnumerable<CategoryObj> items) : base(items){}
    }
    
    
    cat = new CategoryObjCollection(qry);
