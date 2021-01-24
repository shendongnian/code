    private static readonly DateTime[] periodEndings = new DateTime[] {
            DateTime.Today + new TimeSpan (8, 40, 0),
            DateTime.Today + new TimeSpan (9, 20, 0),
            DateTime.Today + new TimeSpan (10, 0, 0),
            DateTime.Today + new TimeSpan (10, 40, 0),
            DateTime.Today + new TimeSpan (11, 20, 0),
            DateTime.Today + new TimeSpan (12, 0, 0),
            DateTime.Today + new TimeSpan (12, 40, 0),
            DateTime.Today + new TimeSpan (13, 20, 0),
            DateTime.Today + new TimeSpan (14, 0, 0),
            DateTime.Today + new TimeSpan (14, 40, 0),
            DateTime.Today + new TimeSpan (15, 20, 0),
            DateTime.Today + new TimeSpan (16, 0, 0),
        };
    static string CalculateTimeToNextPeriod(DateTime now) {
        if (now < periodEndings[0]) {
            return "School hasn't started";
        };
        for (var i = 1; i < periodEndings.Length; ++i) {
            if (now > periodEndings[i - 1] && now < periodEndings[i]) {
                var timeLeft = periodEndings[i] - now;
                return timeLeft.ToString(@"hh\:mm\:ss");
            }
        }
        //otherwise
        return "School's over for the day";
    }
