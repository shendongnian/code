    [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody]Account account)
            {
                try
                {
                    using (PerformanceTimer.StartNew("Performing GraphQL query", str=> LogHelper.Info(str)))
                    {
                        if (!ModelState.IsValid)
                        {
                            return null;
                        }
