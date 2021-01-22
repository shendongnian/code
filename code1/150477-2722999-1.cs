    float usedAmount;
    // try parsing with "fr-FR" first
    bool success = float.TryParse(inputUsedAmount.Value,
                                  NumberStyles.Float | NumberStyles.AllowThousands,
                                  new CultureInfo("fr-FR"),
                                  out usedAmount);
    if (!success)
    {
        // parsing with "fr-FR" failed so try parsing with InvariantCulture
        success = float.TryParse(inputUsedAmount.Value,
                                 NumberStyles.Float | NumberStyles.AllowThousands,
                                 CultureInfo.InvariantCulture,
                                 out usedAmount);
    }
