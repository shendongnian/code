    public decimal NumberReevaluate(decimal number, bool isPositive)
    {
        var tempNumber = System.Math.Abs(number);
        return isPositive ? tempNumber : -tempNumber;
    }
