    string disposition = chargeRow.Field<string>("Disposition");
    if (DispoToPredicateMap.ContainsKey(disposition))
    {
        foreach (DataRow sentenceRow in chargeRow.GetChildRows("FK_Sentence_Charge"))
        {
           if (DispoToPredicateMap[disposition](sentenceRow))
           {
              sentenceRow.SetField("StatusDate", eventDate);
           }
        }
    }
