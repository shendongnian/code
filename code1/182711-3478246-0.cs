    static class ConvertTest
    {
        static IDictionary<Type, IDictionary<Type, Func<AnnotationBase, AnnotationMark>>> _conversions =
            new Dictionary<Type, IDictionary<Type, Func<AnnotationBase, AnnotationMark>>>();
        public static TTo Convert<TFrom, TTo>(this TFrom source)
            where TFrom : AnnotationBase
            where TTo : AnnotationMark
        {
            var conversion = _conversions[typeof(TFrom)][typeof(TTo)];
            return (TTo)conversion(source);
        }
        public static void RegisterConversion<TFrom, TTo>(Func<TFrom, TTo> conversion)
            where TFrom : AnnotationBase
            where TTo : AnnotationMark
        {
            IDictionary<Type, Func<AnnotationBase, AnnotationMark>> toDictionary;
            if (!_conversions.TryGetValue(typeof(TFrom), out toDictionary))
            {
                toDictionary = new Dictionary<Type, Func<AnnotationBase, AnnotationMark>>();
                _conversions.Add(typeof(TFrom), toDictionary);
            }
            toDictionary[typeof(TTo)] = (Func<AnnotationBase, AnnotationMark>)conversion;
        }
    }
