    public static void CrossRates(List<FxRate> rates)
    {
        for (int i = 0; i < rates.Count; i++)
        {
            FxRate rate = rates[i];
            for (int j = i + 1; j < rates.Count; j++)
            {
                FxRate rate2 = rates[j];
                FxRate cross = CanCross(rate, rate2);
                if (cross != null)
                    if (rates.FirstOrDefault(r => r.Ccy1.Equals(cross.Ccy1) && r.Ccy2.Equals(cross.Ccy2)) == null)
                        rates.Add(cross);
            }
        }
    }
    
