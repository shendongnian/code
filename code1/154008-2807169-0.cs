    protected int GetHourRateDB(string serviceType, Size size)
    {
        using (CalculatorLinqDataContext context = new CalculatorLinqDataContext())
        {
            var data =
                (from calculatorData in context.CalculatorDatas
                where calculatorData.Service == serviceType
                select calculatorData).Single();
            switch (size) {
                case Small:
                    return data.Small;
                case Medium:
                    return data.Medium;
                case Large:
                    return data.Large;
                default:
                    // Error handling
             }
         }
    }
