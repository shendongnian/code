    var matchedques = from q in dc.GetTable<Question>()
                                where q.QuestionText.Contains(quesText)
                                select new DateLastUsed() {
                                    DLUID = Guid.NewGuid(),
                                    QuestionID = q.QuestionID,
                                    DateLastUsed1 = DateTime.Now
                                };
    Table<DateLastUsed> dlused = Repository.GetDateLastUsedTable();
    foreach(var dlu in matchedques)
    {
        dlused.InsertOnSubmit(dlu);
        dlused.Context.SubmitChanges();
    }
