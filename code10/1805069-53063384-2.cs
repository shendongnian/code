    public Populate()
    {
        int _i = 0;
        double[] nirData = new double[4];
            MyDevice.Characteristic.ValueUpdated += (sender, e) =>
            {
                nirData[_i] = BitConverter.ToDouble(e.Characteristic.Value, 0);
                _i++;
            };
        Assay assay = new Assay();
        assay.Band = nirData;
    }
