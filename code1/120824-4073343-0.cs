    public class MappingService : IMappingService
    {
        public static Func<object, Type, Type, object> AutoMap = (a, b, c) =>
        {
            throw new InvalidOperationException(
                "The Mapping function must be set on the MappingService class");
        };
        public PagedList<TDestinationElement> MapToViewModelPagedList<TSourceElement, TDestinationElement>(PagedList<TSourceElement> model)
        {
            var mappedList = MapPagedListElements<TSourceElement, TDestinationElement>(model);
            var index = model.PagerInfo.PageIndex;
            var pageSize = model.PagerInfo.PageSize;
            var totalCount = model.PagerInfo.TotalCount;
            return new PagedList<TDestinationElement>(mappedList, index, pageSize, totalCount);
        }
        public object Map<TSource, TDestination>(TSource model)
        {
            return AutoMap(model, typeof(TSource), typeof(TDestination));
        }
        public object Map(object source, Type sourceType, Type destinationType)
        {
            if (source is IPagedList)
            {
                throw new NotSupportedException(
                    "Parameter source of type IPagedList is not supported. Please use MapToViewModelPagedList instead");
            }
            if (source is IEnumerable)
            {
                IEnumerable<object> input = ((IEnumerable)source).OfType<object>();
                Array a = Array.CreateInstance(destinationType.GetElementType(), input.Count());
                int index = 0;
                foreach (object data in input)
                {
                    a.SetValue(AutoMap(data, data.GetType(), destinationType.GetElementType()), index);
                    index++;
                }
                return a;
            }
            return AutoMap(source, sourceType, destinationType);
        }
        private static IEnumerable<TDestinationElement> MapPagedListElements<TSourceElement, TDestinationElement>(IEnumerable<TSourceElement> model)
        {
            return model.Select(element => AutoMap(element, typeof(TSourceElement), typeof(TDestinationElement))).OfType<TDestinationElement>();
        }
    }
