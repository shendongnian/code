    // The wrapper
    public class DataSourceResultWithWarnings: DataSourceResult
    {
        public object Warnings { get; }
        public DataSourceResultWithWarnings(DataSourceResult dataSourceResult, IDictionary<string, IDictionary<string, IList<string>>> warnings)
        {
            this.AggregateResults = dataSourceResult.AggregateResults;
            this.Data = dataSourceResult.Data;
            this.Errors = dataSourceResult.Errors;
            this.Total = dataSourceResult.Total;
            Warnings = warnings;
        }
    }
    
    // The extension method
    public static IDictionary<string, IDictionary<string, IList<string>>> GetWarnings(this ModelStateDictionary msd)
    {
        var result = new Dictionary<string, IDictionary<string, IList<string>>>();
        for (var i = 0; i < msd.Values.Count; i++)
        {
            var wms = msd.Values.ElementAt(i) as WarningModelState;
            if (wms != null)
            {
                if (!result.ContainsKey(msd.Keys.ElementAt(i)))
                {
                    result.Add(msd.Keys.ElementAt(i), new Dictionary<string, IList<string>>() { { "warnings", new List<string>() } });
                }
                result[msd.Keys.ElementAt(i)]["warnings"].AddRange((from rec in wms.Warnings select rec.ErrorMessage));
            }
        }
        return result;
    }
    // How to use it in the controller action
    var result = new DataSourceResultWithWarnings(files.Values.ToDataSourceResult(request, ModelState), ModelState.GetWarnings());
    return Json(result, JsonRequestBehavior.AllowGet);
