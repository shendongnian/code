    public static class IPageObjectExtensions
    {
        public static Control<TOwner> GetActiveControl<TOwner>(this IPageObject<TOwner> pageObject)
            where TOwner : PageObject<TOwner>
        {
            return pageObject.Controls.Create<Control<TOwner>>(
                "<Active>",
                new DynamicScopeLocator(so => AtataContext.Current.Driver.SwitchTo().ActiveElement()));
        }
    }
