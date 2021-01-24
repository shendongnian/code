    private bool MatchMe(string programId, string targetAward, string targetLevel, Program programRecord)
    {
        var isMatched = programRecord.Status == "Active"
            && (string.IsNullOrEmpty(programId) ? true : programRecord.Pid == programId)
            && (string.IsNullOrEmpty(targetAward) ? true : programRecord.Award == targetAward)
            && (string.IsNullOrEmpty(targetLevel) ? true : programRecord.Level == targetLevel);
        return isMatched;
    }
