    public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var token = context.HttpContext.Request.QueryString.HasValue ? context.HttpContext.Request.QueryString.Value.Substring(7) : String.Empty;
                var jsonDecoded = decoder.Decode(token);
                var jwtObject = JsonConvert.DeserializeObject<JwtToken>(jsonDecoded);
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                //Do something here
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                //Do something here
            }
        }
