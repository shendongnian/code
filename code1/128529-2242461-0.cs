    voters.TakeWhile(p => {
       bool exceeded = voicesSoFar > voicesNeeded ;
       voicesSoFar += p.Voices;
       return exceeded;
    });
