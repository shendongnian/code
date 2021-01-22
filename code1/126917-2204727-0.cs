    public static bool? IsThisWeek(DateTime? dt)
    {
        return (dt != null) ? (bool?)(dt.Value > DateTime.Today.AddDays(-7)) : null;
    }
    var deliveredBeforeThisWeek = shipments.Where(s =>
        (!IsThisWeek(s.DeliveryDate) == true));
