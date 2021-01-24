    public static decimal ToProperAmountValue(this Car car)
    {
        return car.IsCarBought ? -car.Amount : car.Amount;
    }
    // TODO: invent proper method name
