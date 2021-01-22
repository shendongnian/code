    public static class FormExtensions
    {
            public static IQueryable<FormItem> GetOrderedItems(this Form form)
            {
                    // without lazy loading, but you have to get current context somehow
                    return CurrentContext.FormItems.Where(x => x.FormId == form.Id).OrderBy(x => x.DisplayOrder);
                   // with lazy loading
                   return form.FormItems.OrderBy(x => x.DisplayOrder);
            }
    }
