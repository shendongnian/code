    var nvEngine = new NVelocityEngine();
    nvEngine.Context.Add("FullName", fullName);
    nvEngine.Context.Add("MallName", voucher.Mall.Name);
    nvEngine.Context.Add("ConfirmationCode", voucher.ConfirmationCode);
    nvEngine.Context.Add("BasePath", basePath);
    nvEngine.Context.Add("TermsLink", termsLink);
    nvEngine.Context.Add("LogoFilename", voucher.Mall.LogoFilename);
    
    var htmlTemplate = System.IO.File.ReadAllText(
        Request.MapPath("~/App_Data/Templates/Voucher.html"));
    
    var email = nvEngine.Render(htmlTemplate);
