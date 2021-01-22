    var epochValue = 1420070400000 // value pulled from server.
    var utcDateVal = new Date(epochValue);
    var actualDate = new Date(utcDateVal.getTime() + (utcDateVal.getTimezoneOffset() * 60 * 1000))
    console.log(utcDateVal); // Wed Dec 31 2014 19:00:00 GMT-0500 (Eastern Standard Time)
    console.log(actualDate); // Thu Jan 01 2015 00:00:00 GMT-0500 (Eastern Standard Time)
