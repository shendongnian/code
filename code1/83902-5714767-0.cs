    var lstSynonym = TechContext.TermSynonyms
                    .Where(p => p.Name.StartsWith(startLetter))
                    .AsEnumerable()
                    .Select(u => new SearchTerm
                                     {
                                         ContentId = u.ContentId,
                                         Title = u.Name,
                                         Url = u.Url
                                     });
