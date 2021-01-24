private ActionResult<T> ConvertToJson<T>(T result)
{           
    // needed to get the same date and property formatting 
    // as the Search Service:
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
    };
    return Json(result, settings);
}
