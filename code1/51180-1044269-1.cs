    public class EnumToReadOnlyCollection<T,TEnum> : ReadOnlyCollection<T> where T: IValueDescritionItem,new() where TEnum : struct
    {
        Type _type;
        
        public EnumToReadOnlyCollection() : base(new List<T>())
        {
            _type = typeof(TEnum);
            if (_type.IsEnum)
            {
                FieldInfo[] fields = _type.GetFields();
                foreach (FieldInfo enum_item in fields)
                {
                    if (!enum_item.IsSpecialName)
                    {
                        T item = new T();
                        item.Value = (int)enum_item.GetValue(null);
                        item.Description = ((ItemDescription)enum_item.GetCustomAttributes(false)[0]).Description;
                        //above line should be replaced with proper code that gets the description attribute
                        Items.Add(item);
                    }
                }
            }
            else
                throw new Exception("Only enum types are supported.");
        }
        public T this[TEnum key]
        {
            get 
            {
                return Items[Convert.ToInt32(key)];
            }
        }
    }
