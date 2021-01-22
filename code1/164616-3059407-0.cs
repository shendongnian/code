            using (KeywordQuery keywordQuery = new KeywordQuery(context))
            {
                keywordQuery.ResultTypes = ResultType.RelevantResults;
                keywordQuery.EnableStemming = true;
                keywordQuery.TrimDuplicates = true;
                keywordQuery.StartRow = 0;
                keywordQuery.SortList.Add(filterField, SortDirection.Ascending);
       
               keywordQuery.QueryText = string.Format(CultureInfo.InvariantCulture, "scope:\"{0}\"", "people");
                keywordQuery.SelectProperties.Add("FirstName");
               
                ResultTableCollection resultsCollection = keywordQuery.Execute();
                ResultTable resultsTable = resultsCollection[ResultType.RelevantResults];}
