    static void Main(string[] args)
    {
      string dirtyXml = @"""<?xml version=\""1.0\"" encoding=\""UTF-8\""?>\n\n<ISBNdb server_time=\""2010-01-28T11:31:08Z\"">\n<BookList total_results=\""1\"" page_size=\""10\"" page_number=\""1\"" shown_results=\""1\"">\n<BookData book_id=\""quantitative_techniques\"" isbn=\""0826458548\"" isbn13=\""9780826458544\"">\n<Title>Quantitative techniques</Title>\n<TitleLong></TitleLong>\n<AuthorsText>Terry Lucey</AuthorsText>\n<PublisherText publisher_id=\""continuum\"">London : Continuum, 2002.</PublisherText>\n</BookData>\n</BookList>\n</ISBNdb>\n""";
      Console.WriteLine(dirtyXml);
      Console.WriteLine();
      Console.WriteLine(Regex.Replace(dirtyXml, @"^""|""$|\\n?", ""));
    }
