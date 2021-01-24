    public interface IGenericEnumViewModel
    {
        Enum Value { get; }
        GenericEnumViewModel<SelectListItem> Options { get; }
    }
    public class GenericEnumViewModel<TEnum> : IGenericEnumViewModel where TEnum : struct
    {
        [Required]
        public TEnum? Value { get; set; }
        public GenericEnumViewModel<SelectListItem> Options { get; set; }
        Enum IGenericEnumViewModel.Value => Value.HasValue ? Value.Value : (Enum)null;
    }
    // ...
    if (obj is IGenericEnumViewModel castedObj)
    {
        // do something with castedObj.Value and castedObj.Options.
        Enum value = castedObj.Value;
        // ...
    }
