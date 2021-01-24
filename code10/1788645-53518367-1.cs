        public async Task<CosmosSearchResponse<Model.Contact>> 
        GetContactsBySearchCriteriaAsync(int pageSize, long companyId, 
        CosmosSearchCriteria searchCriteria, string continuationToken = null)
        {
            var collectionName = CreateCollectionName(companyId, Constants.CollectionType.Contacts);
            var feedOptions = new FeedOptions { MaxItemCount = pageSize };
            if (!String.IsNullOrEmpty(continuationToken))
            {
                feedOptions.RequestContinuation = continuationToken;
            }
            var collection = UriFactory.CreateDocumentCollectionUri(
                    Configuration.GetValue<string>(Constants.Settings.COSMOS_DATABASE_SETTING),
                    collectionName);
            IOrderedQueryable<Model.Contact> documents = Client.CreateDocumentQuery<Model.Contact>(
                collection,
                feedOptions
            );
            documents = (IOrderedQueryable<Model.Contact>)documents.Where(document => document.deleted != true);
            bool requiresConcatenation = false;
            foreach (var criteria in searchCriteria.Criteria)
            {
                switch (criteria.CriteriaType)
                {
                    case Constants.CosmosCriteriaType.ContactProperty:
                        // This is where predicates for the documents.Where(xxxx) 
                        // clauses are built dynamically with Expressions.
                        documents = AddContactPropertyClauses(documents, criteria);
                        break;
                    case Constants.CosmosCriteriaType.PushCampaignHistory:
                        requiresConcatenation = true;
                        break;
                }
            }
            documents = (IOrderedQueryable<Model.Contact>)documents.AsDocumentQuery();
            /*
                From this point onwards, we have to do some wizardry to get around the fact that there is no Linq to SQL
                extension overload for the Cosmos DB function ARRAY_CONTAINS (<arr_expr>, <expr> , bool_expr).
                The feature is planned for development but is not yet ready. 
                Keep an eye on the following for updates:
                    https://stackoverflow.com/questions/52412557/cosmos-db-use-array-contains-in-linq
                    https://feedback.azure.com/forums/263030-azure-cosmos-db/suggestions/11503872-support-linq-any-or-where-for-child-object-collect
            */
            if (requiresConcatenation)
            {
                var sqlString = documents.ToString();
                var jsonDoc = JsonConvert.DeserializeObject<dynamic>(sqlString); // Have to do this to remove the escaping
                var q = (string)jsonDoc.query;
                var queryRootAlias = Util.GetAliasNameFromQuery(q);
                if (queryRootAlias == string.Empty)
                {
                    throw new FormatException("Unable to parse root alias from query.");
                }
                foreach (var criteria in searchCriteria.Criteria)
                {
                    switch (criteria.CriteriaType)
                    {
                        case Constants.CosmosCriteriaType.PushCampaignHistory:
                            q += string.Format(" AND ARRAY_CONTAINS({0}[\"CampaignHistory\"], {{\"CampaignType\":1,\"CampaignId\":{1}, \"IsOpened\": true }}, true) ", queryRootAlias, criteria.PropertyValue);
                            break;
                    }
                }
                documents = (IOrderedQueryable<Model.Contact>)Client.CreateDocumentQuery<Model.Contact>(
                    collection,
                    q,
                    feedOptions
                ).AsDocumentQuery();
            }
            var returnValue = new CosmosSearchResponse<Model.Contact>();
            returnValue.Results = new List<Model.Contact>();
            Console.WriteLine(documents.ToString());
            var resultsPage = await ((IDocumentQuery<Model.Contact>)documents).ExecuteNextAsync<Model.Contact>();
            returnValue.Results.AddRange(resultsPage);
            if (((IDocumentQuery<Model.Contact>)documents).HasMoreResults)
            {
                returnValue.ContinuationToken = resultsPage.ResponseContinuation;
            }
            return returnValue;
        }  
