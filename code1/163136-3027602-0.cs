    interface INumber
    {
        int Sign { get; }
        INumber Scale(double amount);
    }
