    RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
                if (string.IsNullOrEmpty(recaptchaHelper.Response))
                {
                    ModelState.AddModelError("reCAPTCHA", "Please complete the reCAPTCHA");
                    return CurrentUmbracoPage();
                }
                else
                {
                    RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
                    if (recaptchaResult != RecaptchaVerificationResult.Success)
                    {
                        ModelState.AddModelError("reCAPTCHA", "The reCAPTCHA is incorrect");
                        return CurrentUmbracoPage();
                    }
                }
    
    
