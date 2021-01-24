    string dateTimeString = @"03/14/2018";
    string[] possibleStandardFormats = new CultureInfo("en-US")
                                         .DateTimeFormat.GetAllDateTimePatterns();
    DateTime? result = null;
    foreach (string format in possibleStandardFormats) {
        if (DateTime.TryParse(dateTimeString, out DateTime dateTime)) {
            // this format could work
            result = dateTime;
            break;
        }
    }
    if (result == null) {
        // no luck with any format
        // try one last parse
        if (DateTime.TryParse(dateTimeString, out DateTime dateTime)) {
            // finally worked
            result = dateTime;
        }
        else {
            // no luck
        }
    }
