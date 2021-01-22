    public virtual IQueryable<DynamicContent> GetBusinessItemsByExpiryDate(DateTime theDate, int thisPageNo, ref int? totalCount)
        {
            //ToDo: Use FilterExperssion for filtering rather than above; 
            int? itemsToSkip = 0;
            int? itemsPerPage = ItemsPerPageCount;
            string towncity = string.Empty; string strSectorID = string.Empty;
            //Guid sectorID;
            if (pageNo > 0)
            {
                itemsToSkip = itemsPerPage * (pageNo - 1);
            }
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
            Type businessItemType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Businesslisting.BusinessItem");
            var query = dynamicModuleManager.GetDataItems(businessItemType);
            System.Globalization.CultureInfo culture = null;
            culture = System.Globalization.CultureInfo.CurrentUICulture;
            FilterExpression = ContentHelper.AdaptMultilingualFilterExpressionRaw(FilterExpression, culture);
            string filterExpression = DefinitionsHelper.GetFilterExpression(FilterExpression, AdditionalFilter);
            filterExpression += "Visible = true AND Status = Live";
            if (theDate != DateTime.MinValue)
            {
                filterExpression += string.Format(" And ExpiryDate >= ({0}) AND ExpiryDate <= ({1})", theDate.AddDays(-14).ToString("yyyy/MM/dd"), theDate.AddDays(42).ToString("yyyy/MM/dd"));
            }
            SortExpression += "Title";
            query = DataProviderBase.SetExpressions<DynamicContent>(query, filterExpression, SortExpression, itemsToSkip, new int?(itemsPerPage ?? 0), ref totalCount);
            TotalItemCount = (int)totalCount;
            return query;
        }
