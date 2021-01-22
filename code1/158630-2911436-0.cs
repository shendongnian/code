    public class ScrollableCheckboxList<TModel> where TModel : class
    { 
        public List<ScrollableCheckboxItem> listitems; 
     
        public ScrollableCheckboxList(IEnumerable<TModel> items, string valueField, string textField, string titleField)
        { 
            ...
