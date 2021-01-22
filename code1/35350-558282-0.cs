    if (!Double.IsNaN(Price_Foreign))
    {
       output.Append(spacer);
       output.Append(String.Format("{0,-10:C} USD",Price_Foreign));
    }
