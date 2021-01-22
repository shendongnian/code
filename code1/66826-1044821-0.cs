    int completeWeeks = businessDays / 5
    int extraDays = days % 5
    date firstGuess = startDate.AddDays(complateWeeks*7+extraDays)
    if (firstGuess.DayOfWeek == Saturday) {
        return firstGuess.AddDays(2);
    } 
    else if firstGuess.DayOfWeek == Sunday) {
        return firstGuess.AddDays(1);
    }
    else
        return firstGuess;
