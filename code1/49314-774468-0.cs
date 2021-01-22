              Challenge challenge = new Select().From(Challenge.Schema)
               .WhereExpression(Challenge.Columns.ChallengerKey).IsEqualTo(playerKey)
               .Or(Challenge.Columns.ChallengerKey).IsGreaterThan(playerKey)
               .AndExpression(Challenge.Columns.Complete).IsEqualTo(false)
               .ExecuteSingle<Challenge>();
