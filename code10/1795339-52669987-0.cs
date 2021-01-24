    private IQueryable SearchCompanies(string pValues)
        {
            string mValues = pValues;
            foreach (string lWord in iRestrictedWords)
            {
                mValues.Replace(lWord, "");
            }
            var mSearchArray = pValues.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var mCompanyCriteria = db.v_CompanyInquiryInfo.AsExpandable().Where(TradingInquiryController.CompanyContainsSearchTerms(mSearchArray));
    
            var mCompanies = mCompanyCriteria        
    .OrderByDescending(x => mSearchArray.Sum(s => ((x.SearchTags.Length - x.SearchTags.Replace(s, "").Length) / s.Length))
    ;
    
            //var mResults =  mCompanies.Skip(0).Take(20);
            return mCompanies;
        }
