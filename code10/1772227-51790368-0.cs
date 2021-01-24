        // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                var requestTelemetry = this.httpContextAccessor.HttpContext.Features.Get<RequestTelemetry>();
                requestTelemetry.Context.Properties["userId"] = "myuserid"
                return new string[] { "value1", "value2" };
            }
