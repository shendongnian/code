    class Order
    {
        Guid Id;
        DateTime TimeStamp;
        Discount Discount;
    }
    
    class Discount
    {
        Guid Id;
        DayOfWeek Day;
        TimeSpan StartTime;
        TimeSpan EndTime;
        Decimal Amount;
    }
