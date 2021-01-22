    partial class Form
    {
        public IQueryable<FormItem> FormItems
        { 
            get { return PrivateFormItems.OrderBy(x => x.DisplayOrder); } 
        }
    }
