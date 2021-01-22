    TryParseLong valueAsLong = new TryParseLong(value);
    if (valueAsLong.isParsable()) {
        ...
        // Do something with valueAsLong.getLong();
    } else {
        ...
    }
