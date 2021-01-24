    public decimal SumNumericsFromListOfObjects(List<object> objects) {
        decimal sum = 0;
        foreach (object o in objects) {
            decimal val = 0;
            if (decimal.TryParse(o.ToString(), out val)
                sum += val;
        }
        return sum;
    }
    // Usage:
    private void DoSomeCoolStuff() {
        List<object> myObjects = new List<object>();
        object[] objects = new object[] { 12, 32, 1, 9, "5", "18", 3.14, "9.9", false };
        myObjects.AddRange(objects);
        decimal sumOfObjects = SumNumericsFromListOfObjects(myObjects);
        int iSum = 0;
        long lSum = 0;
        if (sumOfObjects < int.MaxValue)
            iSum = (int)sumOfObjects;
        else if (sumOfObjects > int.MaxValue && sumOfObjects < long.MaxValue)
            lSum = (long)sumOfObjects;
        else
            // You just have to use the double type at this point.
    }
