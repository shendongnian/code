    allArticleConcepts = DataAccess.ArticleConceptRepository.AllNoTracking
        .Join(DataAccess.ArticleAnalysisDataRepository.AllNoTracking.Where(aa => aa.CommentCount >= minCommentCount), 
            outer => outer.ArticleId, 
            inner => inner.ArticleId, 
            (outer, inner) => outer)
        .Where(ac => missingXData.Any(x => x.ArticleId == ac.ArticleId))
        .ToList()
        .AsParallel()
        .GroupBy(ac => ac.ArticleId)
        .ToDictionary(grp => grp.Key, grp => grp
            .Select(ac => new Concept { ContextSynLexemId = ac.LexemId, LexemId = ac.LexemId, Frequency = ac.Freq })
            .ToList());
