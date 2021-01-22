    var articles = 
        (from ch in ContentHistories
            .Where(ch=> ch.CompareTag == new Guid("D3C38885-58AB-45CB-A19C-8EF48360F29D")
                && ch.AgainstTag == new Guid("5832933B-9AF9-4DEC-9D8D-DA5F211A5B53")
                & ch.Created > DateTime.Now.AddDays(-3)) // Initial record filtering
        select ch.Content) // Only return the XML Content column
            .Elements("Article") // Get <Article> child elements
            .Select(article => new {
                Id = Convert.ToInt32(article.Element("Id").Value),
                AcessionNumber = (string)article.Element("AcessionNumber").Value,
                Headline = (string)article.Element("Headline").Value,
                PublicationDate = Convert.ToDateTime(article.Element("PublicationDate").Value),
                ArrivalDate = Convert.ToDateTime(article.Element("ArrivalDate").Value),
                Source = (string)article.Element("Source").Value,
                CopyRight = (string)article.Element("CopyRight").Value,
                Language = (string)article.Element("Language").Value,
                WordCount = String.IsNullOrEmpty(article.Element("WordCount").Value) ? 0 : Convert.ToInt32(article.Element("WordCount").Value),
                Snippet = (string)article.Element("Headline").Value,
                LeadParagraph = (string)article.Element("Headline").Value,
                ContentGuid = new Guid(article.Element("ContentGuid").Value)
            }) // Select and coerce data into new object
            .Skip(5) // Skip records for paging in web UI
            .Take(5) // Take only 1 page of records for display;
    articles.Dump();
