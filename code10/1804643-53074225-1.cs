    public static class IDataExtractorExt {
        public static IDataExtractor<TRow> WithAllProperties<TRow>(this IDataExtractor<TRow> extractor) {
            var p = Expression.Parameter(typeof(IDataExtractor<TRow>), "p"); // final lambda parameter
            Expression ansBody = p; // start with p => p
            
            var withPropGenericMI = typeof(IDataExtractor<TRow>).GetMethod("WithProperty"); // lookup WithProperty<> generic method
            var properties = typeof(TRow).GetProperties();
            foreach (var property in properties) {
                var withPropMI = withPropGenericMI.MakeGenericMethod(property.PropertyType); // instantiate generic WithProperty<> to property type
                var pxp = Expression.Parameter(typeof(TRow), "x"); // property accessor lambda parameter
                var pxb = Expression.PropertyOrField(pxp, property.Name); // property accessor expression x.property
                Expression propExpr = Expression.Lambda(pxb, pxp); // x => x.property
                ansBody = Expression.Call(ansBody, withPropMI, propExpr); // build up p => p.WithProperty(x => x.property)...
            }
    
            return ((IDataExtractor<TRow>)(Expression.Lambda(ansBody, p).Compile().DynamicInvoke(extractor)));
        }
    }
