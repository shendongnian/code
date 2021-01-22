    partial class Form
    {
        public IQueryable<FormItem> OrderedFormItems
        { 
            get { return FormItems.OrderBy(x => x.DisplayOrder); } 
        }
    }
