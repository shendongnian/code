    var matches = bigrams.Where(p => p.Phrase == bigram.Phrase).Count();
    
    if (matches == 0)
    {
        bigram.Count = 1;
        bigrams.Add(bigram);
    }
    else
    {
        int bigramToEdit = 
         bigrams.IndexOf(
           bigrams.Where(b => b.Phrase == bigram.Phrase).FirstOrDefault());
        bigrams[bigramToEdit].Count += 1;
    }
