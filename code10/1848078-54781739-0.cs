     public async Task<AzureOperationResponse<AccessKeys>> RegenerateKeysWithHttpMessagesAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, RegenerateAccessKeyParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (resourceGroupName == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
                }
                if (resourceGroupName != null)
                {
                    if (resourceGroupName.Length > 90)
                    {
                        throw new ValidationException(ValidationRules.MaxLength, "resourceGroupName", 90);
                    }
                    if (resourceGroupName.Length < 1)
                    {
                        throw new ValidationException(ValidationRules.MinLength, "resourceGroupName", 1);
                    }
                }
                if (namespaceName == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "namespaceName");
                }
                if (namespaceName != null)
                {
                    if (namespaceName.Length > 50)
                    {
                        throw new ValidationException(ValidationRules.MaxLength, "namespaceName", 50);
                    }
                    if (namespaceName.Length < 6)
                    {
                        throw new ValidationException(ValidationRules.MinLength, "namespaceName", 6);
                    }
                }
                if (authorizationRuleName == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "authorizationRuleName");
                }
                if (authorizationRuleName != null)
                {
                    if (authorizationRuleName.Length > 50)
                    {
                        throw new ValidationException(ValidationRules.MaxLength, "authorizationRuleName", 50);
                    }
                    if (authorizationRuleName.Length < 1)
                    {
                        throw new ValidationException(ValidationRules.MinLength, "authorizationRuleName", 1);
                    }
                }
                if (parameters == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
                }
                if (parameters != null)
                {
                    parameters.Validate();
                }
                if (Client.ApiVersion == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
                }
                if (Client.SubscriptionId == null)
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SubscriptionId");
                }
                // Tracing
                bool _shouldTrace = ServiceClientTracing.IsEnabled;
                string _invocationId = null;
                if (_shouldTrace)
                {
                    _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                    Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                    tracingParameters.Add("resourceGroupName", resourceGroupName);
                    tracingParameters.Add("namespaceName", namespaceName);
                    tracingParameters.Add("authorizationRuleName", authorizationRuleName);
                    tracingParameters.Add("parameters", parameters);
                    tracingParameters.Add("cancellationToken", cancellationToken);
                    ServiceClientTracing.Enter(_invocationId, this, "RegenerateKeys", tracingParameters);
                }
                // Construct URL
                var _baseUrl = Client.BaseUri.AbsoluteUri;
                var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}/regenerateKeys").ToString();
                _url = _url.Replace("{resourceGroupName}", System.Uri.EscapeDataString(resourceGroupName));
                _url = _url.Replace("{namespaceName}", System.Uri.EscapeDataString(namespaceName));
                _url = _url.Replace("{authorizationRuleName}", System.Uri.EscapeDataString(authorizationRuleName));
                _url = _url.Replace("{subscriptionId}", System.Uri.EscapeDataString(Client.SubscriptionId));
                List<string> _queryParameters = new List<string>();
                if (Client.ApiVersion != null)
                {
                    _queryParameters.Add(string.Format("api-version={0}", System.Uri.EscapeDataString(Client.ApiVersion)));
                }
                if (_queryParameters.Count > 0)
                {
                    _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
                }
                // Create HTTP transport objects
                var _httpRequest = new HttpRequestMessage();
                HttpResponseMessage _httpResponse = null;
                _httpRequest.Method = new HttpMethod("POST");
                _httpRequest.RequestUri = new System.Uri(_url);
                // Set Headers
                if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
                {
                    _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
                }
                if (Client.AcceptLanguage != null)
                {
                    if (_httpRequest.Headers.Contains("accept-language"))
                    {
                        _httpRequest.Headers.Remove("accept-language");
                    }
                    _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
                }
                if (customHeaders != null)
                {
                    foreach(var _header in customHeaders)
                    {
                        if (_httpRequest.Headers.Contains(_header.Key))
                        {
                            _httpRequest.Headers.Remove(_header.Key);
                        }
                        _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                    }
                }
                // Serialize Request
                string _requestContent = null;
                if(parameters != null)
                {
                    _requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(parameters, Client.SerializationSettings);
                    _httpRequest.Content = new StringContent(_requestContent, System.Text.Encoding.UTF8);
                    _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                }
                // Set Credentials
                if (Client.Credentials != null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
                }
                // Send Request
                if (_shouldTrace)
                {
                    ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
                }
                cancellationToken.ThrowIfCancellationRequested();
                _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
                if (_shouldTrace)
                {
                    ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
                }
                HttpStatusCode _statusCode = _httpResponse.StatusCode;
                cancellationToken.ThrowIfCancellationRequested();
                string _responseContent = null;
                if ((int)_statusCode != 200)
                {
                    var ex = new ErrorResponseException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                    try
                    {
                        _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        ErrorResponse _errorBody =  Rest.Serialization.SafeJsonConvert.DeserializeObject<ErrorResponse>(_responseContent, Client.DeserializationSettings);
                        if (_errorBody != null)
                        {
                            ex.Body = _errorBody;
                        }
                    }
                    catch (JsonException)
                    {
                        // Ignore the exception
                    }
                    ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                    ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw ex;
                }
                // Create Result
                var _result = new AzureOperationResponse<AccessKeys>();
                _result.Request = _httpRequest;
                _result.Response = _httpResponse;
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                // Deserialize Response
                if ((int)_statusCode == 200)
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    try
                    {
                        _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<AccessKeys>(_responseContent, Client.DeserializationSettings);
                    }
                    catch (JsonException ex)
                    {
                        _httpRequest.Dispose();
                        if (_httpResponse != null)
                        {
                            _httpResponse.Dispose();
                        }
                        throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                    }
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Exit(_invocationId, _result);
                }
                return _result;
            }
