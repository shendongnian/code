            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Web.OData.Query;
            using Axonize.Common.Models.Consts;
            
            namespace Business.BusinessLogic.Translators
            {
            		/// <summary>
            		/// Convert odata query using keywords
            		/// </summary>
            		public class ODataQueryConverter : IODataQueryConverter
            		{
            				private readonly DateTime _serverNow = DateTime.UtcNow;
            				private Dictionary<string, string> KeywordsDictionary { get; set; }
            
            				/// <summary>
            				/// constructor
            				/// </summary>
            				public ODataQueryConverter()
            				{
            						KeywordsDictionary = new Dictionary<string, string>
            						{
            								{ "StartOfTheMonth", new DateTime(_serverNow.Year, _serverNow.Month, 1).ToString(Consts.IsoPattern)},
            								{ "EndOfTheMonth", new DateTime(_serverNow.Year, _serverNow.Month +1,1).AddSeconds(-1).ToString(Consts.IsoPattern)},
            						};
            				}
            
            				/// <summary>
            				/// Convert OData query option to new uri using const keywords
            				/// </summary>
            				/// <param name="odataQuery"></param>
            				/// <returns></returns>
            				public ODataQueryOptions Convert(ODataQueryOptions odataQuery)
            				{
            						if (odataQuery == null)
            								return null;
            
            						var odataRequestMessage = odataQuery.Request;
            						var odataRequestUri = odataRequestMessage.RequestUri.ToString();
            						var newRequestUriString = ConvertKeywords(odataRequestUri);
            
            						odataRequestMessage.RequestUri = new Uri(newRequestUriString);
            						var newOdataQueryOptions = new ODataQueryOptions(odataQuery.Context, odataRequestMessage);
            
            						return newOdataQueryOptions;
            				}
            
            				public string Convert(string odataQueryString)
            				{
            						return ConvertKeywords(odataQueryString);
            				}
            
            				private string ConvertKeywords(string odataRequestUri)
            				{
            						return KeywordsDictionary.Aggregate(odataRequestUri, (current, keyword) => current.Replace(keyword.Key, keyword.Value));
            				}
            		}
            }
      
    //method in some basebussinessController used to query data 
    //_converter is the instance of ODataQueryConverter that got from depedency //injection
    public virtual IQueryable<T> Get(ODataQueryOptions<T> queryOptions)
    {
       var convertedQuery = _converter.Convert(queryOptions);
       var queryable = BusinessController.Get();
       var convertedQueryable = convertedQuery.ApplyTo(queryable);
       return convertedQueryable;
    }
                    
