    try
                {
                    using (var response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        if(!response.IsSuccessStatusCode)
                        {
                            ***var error = await response.Content.ReadAsAsync<ErrorDetails>().ConfigureAwait(false);***
                            throw new HttpRequestException(error.Details);
                        }
                        response.EnsureSuccessStatusCode();
                        var result = await response.Content.ReadAsAsync<TResponse>().ConfigureAwait(false);
                        return result;
                    }
                }
