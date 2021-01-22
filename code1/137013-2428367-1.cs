    public double Rate(string baseCode, string targetCode)
    {
        if (_graph[baseCode].Contains(targetCode)) {
            // found the target code
            return GetKnownRate(baseCode, targetCode);
        }
        else {
            foreach (var code in _graph[baseCode]) {
                // determine if code can be converted to targetCode
                double rate = Rate(code, targetCode);
                if (rate != 0) // if it can than combine with returned rate
                    return rate * GetKnownRate(baseCode, code);
            }
        }
        return 0; // baseCode cannot be converted to the targetCode
    }
    public double GetKnownRate(string baseCode, string targetCode) 
    {
        var rate = rates.SingleOrDefault(fr => fr.Base == baseCode && fr.Target == targetCode);
        var rate_i rates.SingleOrDefault(fr => fr.Base == targetCode && fr.Target == baseCode));
        if (rate == null)
            return 1 / rate_i.Rate
        return rate.Rate;
    }
