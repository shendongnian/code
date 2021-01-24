    if (e.ChartElementType == ChartElementType.DataPointLabel) {
        switch (e.HitTestResult.Series.Name)
        {
            case "My series 1 name":
                ...
                break;
            case "My series 2 name":
                ...
                break;
        }
    }
