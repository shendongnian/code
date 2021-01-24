    signInManager
        .Setup(x => x.PasswordSignInAsync(It.IsAny<string>(),
                                          It.IsAny<string>(),
                                          It.IsAny<bool>(),
                                          It.IsAny<bool>()))
             .ReturnsAsync(Microsoft.AspNet.Identity.Owin.SignInStatus.Failure);
    
