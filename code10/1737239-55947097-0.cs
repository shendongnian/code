using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Extensions.DependencyInjection;
namespace YourNameSpace
{
    public class RateFilter : Attribute, IResourceFilter
    {
        private const string EndPoint = "YourEndPoint";
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            try
            {
                if (!context.HttpContext.Request.Path.Value.Contains(EndPoint))
                {
                    throw new Exception($"This filter is intended to be used only on a specific end point '{EndPoint}' while it's being called from '{context.HttpContext.Request.Path.Value}'");
                }
                var minRequestRateFeature = context.HttpContext.Features.Get<IHttpMinRequestBodyDataRateFeature>();
                var minResponseRateFeature = context.HttpContext.Features.Get<IHttpMinResponseDataRateFeature>();
                //Default Bytes/s = 240, Default TimeOut = 5s
                if (minRequestRateFeature != null)
                {
                    minRequestRateFeature.MinDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                }
                if (minResponseRateFeature != null)
                {
                    minResponseRateFeature.MinDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                }
            }
            catch (Exception ex)
            {
                //Log or Throw
            }
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
Then you can use the attribute on a specific end point like
        [RateFilter]
        [HttpPost]
        public IActionResult YourEndPoint(YourModel request)
        {
            return Ok();
        }
 - You can further customize the filter to take in the endpoint/rates as
   ctor parameters. 
 - You can also remove the check for specific endpoint
 - You can `return` instead of `throw`
   
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2#resource-filters
