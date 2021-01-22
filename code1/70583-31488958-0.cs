    public static class EnumHelper
    {
        public static List<ItemDto> EnumToCollection<T>()
        {
            return (Enum.GetValues(typeof(T)).Cast<int>().Select(
                e => new ItemViewModel
                         {
                             IntKey = e,
                             Value = Enum.GetName(typeof(T), e)
                         })).ToList();
        }
    }
