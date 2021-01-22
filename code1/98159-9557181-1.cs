    void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
    {
        if (e.ElementType == ChartElementType.AxisLabels &&
            e.ValueType == ChartValueType.Int64 && 
            e.Format == "MyAxisXCustomFormat")
        {
            e.LocalizedValue = DateTime.FromFileTimeUtc((long)e.Value).ToShortDateString();
        }
    }
