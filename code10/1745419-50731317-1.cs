    public class ServiceOptionsController : BaseServiceController
    {
      [AcceptVerbs("POST")]
      public List<OptionModel> Options([FromBody] dynamic data)
      {
        var selectors = data.ToObject<QueryModel>();
    
        var optionModel = new OptionModel
        {
          Symbol = "MSFT",
          Expiration = "201806"
        };
    
        var optionService = new OptionService();
    
        var processes = new List<Task<List<OptionModel>>>
        {
          optionService.GetOptionsChain(optionModel)
        };
    
        var items = Task.WhenAll(processes).Result.SelectMany(o => o).ToList();
    
        optionService.Dispose(); // Ridiculous fix for ridiculous API
    
        return items;
      }
    }
