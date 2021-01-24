    private UInt64 binary;
    public UInt64 Binary { get { return binary; } set { binary = value; UpdateUi(); } }
    public double Value { get { return BinaryToValue(); } set { ValueToBinary(value); } }
    private double BinaryToValue()
    {
        double binaryToValue = 0;
        // logic (convert binary field to double and set it to binaryToValue)
        return binaryToValue;
    }
    private double lastValue;
    private void ValueToBinary(double value)
    {
        if (value != lastValue)
        {
            lastValue = value;
            // logic (Binary (the property to activate UpdateUi()) = ...)
        }
    }
