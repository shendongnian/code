    public static class Util {
        static Expression<Func<string, int>> TermOrderTemplateFn = p => (p == "Fall" ? 1 : p == "Spring" ? 2 : 3);
        public static Expression<Func<TRec, int>> TermsOrder<TRec>(Expression<Func<TRec, string>> selectorFn) =>
            TermOrderTemplateFn.Compose(selectorFn);
    }
