    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("name", user.UserName),
                };
                var identity = new ClaimsIdentity(claims, "Test");
                var claimsPrincipal = new ClaimsPrincipal(identity);
    
                var mockPrincipal = new Mock<IPrincipal>();
                mockPrincipal.Setup(x => x.Identity).Returns(identity);
                mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
    
                var mockHttpContext = new Mock<HttpContext>();
                mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);
