    public interface IGenericEnumViewModel
    {
        object Value { get; set; }
        GenericEnumViewModel<SelectListItem> Options { get; set; }
    }
    
    public class GenericEnumViewModel<TEnum> : IGenericEnumViewModel where TEnum : struct
    {
        public TEnum? Value { get; set; }
        public GenericEnumViewModel<SelectListItem> Options { get; set; }
    	
    		object IGenericEnumViewModel.Value {
		           get {return Value;}
		           set {Value = (TEnum?)value;}
    }
