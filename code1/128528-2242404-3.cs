    var eligibleVoters = voters.TakeUntil(
                             p => (voicesSoFar += p.Voices) >= voicesNeeded
                         );
    foreach(var voter in eligibleVoters) {
        Console.WriteLine(voter.Name);
    }
