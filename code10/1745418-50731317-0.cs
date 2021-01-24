    public class ServiceOptionsController : BaseServiceController
    {
      OptionService Service = new OptionService();
    
      [AcceptVerbs("POST")]
      public async Task<List<OptionModel>> Options([FromBody] dynamic data)
      {
        var selectors = data.ToObject<QueryModel>();
    
        var optionModel = new OptionModel
        {
          Symbol = "MSFT",
          Expiration = "201806"
        };
    
        var processes = new List<Task<List<OptionModel>>>
        {
          Service.GetOptionsChain(optionModel)
        };
    
        return (await Task.WhenAll(processes)).SelectMany(o => o).ToList();
      }
    }
