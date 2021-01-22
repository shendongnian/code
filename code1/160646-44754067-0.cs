    var now = DateTime.UtcNow;
    // 636340541021531973, 2017-06-26T06:08:22.1531973Z
    
    var millisecondsPrecision = new DateTime(now.Ticks / 10000 * 10000, now.Kind);
    // 636340541021530000, 2017-06-26T06:08:22.1530000Z
    
    var secondsPrecision = new DateTime(now.Ticks / 10000000 * 10000000, now.Kind);
    // 636340541020000000, 2017-06-26T06:08:22.0000000Z
    
    var minutePrecision = new DateTime(now.Ticks / (10000000*60) * (10000000*60), now.Kind);
    // 636340541000000000, 2017-06-26T06:08:00.0000000Z
