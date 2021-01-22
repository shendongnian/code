            Id(x => x.Id);
            HasMany(x => x.Rates)
                .AsMap(x => x.Type)
                .KeyColumn("Item_Id")
                .Table("InvoiceItem_Rates")
                .Component(x =>
                               {
                                   x.Map(r => r.Amount);
                                   x.Map(r => r.Quantity);
                               })
                .Cascade.AllDeleteOrphan();            
