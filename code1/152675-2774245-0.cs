    Comparison<topLevelItem> itemComparison = (x, y) => {
        DateTime dx;
        DateTime dy;
        bool xParsed = DateTime.TryParse(x.subLevelItem.DeliveryTime, out dx);
        bool yParsed = DateTime.TryParse(y.subLevelItem.DeliveryTime, out dy);
        if (xParsed && yParsed)
            return dx.CompareTo(dy);
        else if (xParsed)
            return -1; // or 1, if you want invalid strings to come first
        else if (yParsed)
            return 1; // or -1, if you want invalid strings to come first
        else
            // simple string comparison
            return x.subLevelItem.DeliveryTime.CompareTo(y.subLevelItem.DeliveryTime);
    };
    items.Sort(itemComparison);
