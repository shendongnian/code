     partial class FormDerived
        {
            public override IQueryable<FormItem> FormItems
            { 
                get { return base.FormItems.OrderBy(x => x.DisplayOrder); } 
            }
        }
