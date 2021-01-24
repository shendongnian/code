    public static class EFExt {
        static Expression<Func<string, int>> TermThenOrderTemplateFn = p => (p == "Fall" ? 1 : p == "Spring" ? 2 : 3);
        public static IOrderedQueryable<T> ThenByTerm<T>(this IOrderedQueryable<T> src, Expression<Func<T, string>> selectorFn) =>
            src.ThenBy(TermThenOrderTemplateFn.Compose(selectorFn));
    }
