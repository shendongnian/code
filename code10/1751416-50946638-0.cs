    public static class InvoicesExtensions
    {
        public static OrderArticleViewModel ToOrderArticleViewModel(this Invoices i)
        {
            return new OrderArticleViewModel { ArticleId = i.ArtId, ... };
        }
    }
