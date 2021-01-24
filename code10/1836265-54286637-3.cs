    List<structBooks> listBooks = new List<structBooks>();
    listBooks.Add(new structBooks()
    {
        strBookName = "bookName",
        strAuthor = "author",
        publishedDate = new structPubished
          {
            intDayOfMonth = intNewDayOfMonth,
            intMonthOfYear = intNewMonthOfYear,
            intYear = intNewYear
          }
    });
