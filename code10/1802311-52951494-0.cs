    using (var client = new HttpClient())
            {
                HttpResponseMessage result = client.PostAsync(getTokenUrl, content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                var token = JsonConvert.DeserializeObject<Token>(resultContent);
                
                if (string.IsNullOrEmpty(token.access_token))
                {
                    ViewBag.Error = "Incorrect Username or Password, Please try again!";
                    return View("Login");
                }
                var options = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.expires_in))
                }; 
                /*var claims = new[]
                {
                    new Claim(ClaimTypes.Email, account.Login.Email),
                    new Claim("AccessToken", $"Bearer {token.access_token}"),
                };*/
                //JwtSecurityToken returns all the properties from the token service
                var jwtToken = new JwtSecurityToken(token.access_token);
                var identity = new ClaimsIdentity(jwtToken.Claims, DefaultAuthenticationTypes.ApplicationCookie,ClaimTypes.Name,ClaimTypes.Role);
                Request.GetOwinContext().Authentication.SignIn(options, identity);
                if (identity.HasClaim(ClaimTypes.Role, "Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "User");
            }
