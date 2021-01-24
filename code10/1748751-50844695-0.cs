            IAsyncPolicy<HttpResponseMessage> rejectSqlError = Policy<HttpResponseMessage>
                .HandleResult(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .FallbackAsync(async (delegateOutcome, context, token) =>
                {
                    String stringContent = await delegateOutcome.Result.Content.ReadAsStringAsync(); // Could wrap this line in an additional policy as desired.
                    if (delegateOutcome.Result.StatusCode == HttpStatusCode.InternalServerError && stringContent.Contains("SqlDateTime overflow"))
                    {
                        throw new CustomSqlDateOverflowException(); // Replace 500 SqlDateTime overflow with something else.
                    }
                    else
                    {
                        return delegateOutcome.Result; // render all other 500s as they were
                    }
                }, async (delegateOutcome, context) => { /* log (if desired) that InternalServerError was checked for what kind */ });
            IAsyncPolicy<HttpResponseMessage> retryPolicy = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .OrResult(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .OrResult(r => /* condition for any other errors you want to handle */)
                .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    async (exception, timeSpan, context) =>
                    {
                        /* log (if desired) retry being invoked */
                    });
            HttpResponseMessage response = await retryPolicy.WrapAsync(rejectSqlError)
                .ExecuteAsync(() => client.PostAsync(requestUri, new StringContent(serialisedParameters, Encoding.UTF8, "application/json"), cancellationToken));
