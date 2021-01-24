    var Services = (
        from sa in _ctx.ServiceAttrs
        join pp in _ctx.ProcessorProducts
            on
                new { ServiceId = sa.ServiceID, PrsnPk = ActivePrsnPk }
            equals
                new { ServiceId = pp.ServiceID, PrsnPk = pp.PrsnPK } into tmp
        from PersonServices in tmp.DefaultIfEmpty()
        select new ReviewerServiceDto() {
            ServiceId = sa.ServiceID,
            ServiceAliasDescription = sa.ServiceAlias,
            IsSelected = PersonServices.IsActivated != null
        }
    )
    .OrderBy(dto => dto.ServiceAliasDescription)
    .ToList();
