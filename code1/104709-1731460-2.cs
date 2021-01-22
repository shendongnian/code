    public ActionResult ViewVoucher(string e)
    {
        e = e.Replace(' ', '+');
        var decryptedEmail = CryptoHelper.Decrypt(e);
        var voucher = Voucher.FindByEmail(decryptedEmail);
        if (voucher == null) return View("Error", new Exception("Voucher not found."));
    
        var basePath = new Uri(Request.Url, Url.Content("~/")).ToString();
        var termsLink = new Uri(Request.Url, Url.Action("TermsGC", "Legal")).ToString();
        basePath = basePath.Substring(0, basePath.Length - 1);
    
        var fullName = voucher.FirstName;
        if (!string.IsNullOrEmpty(voucher.LastName))
            fullName += " " + voucher.LastName;
    
        var nvEngine = new NVelocityEngine();
        nvEngine.Context.Add("FullName", fullName);
        nvEngine.Context.Add("MallName", voucher.Mall.Name);
        nvEngine.Context.Add("ConfirmationCode", voucher.ConfirmationCode);
        nvEngine.Context.Add("BasePath", basePath);
        nvEngine.Context.Add("TermsLink", termsLink);
        nvEngine.Context.Add("LogoFilename", voucher.Mall.LogoFilename);
    
        var htmlTemplate = System.IO.File.ReadAllText(
            Request.MapPath("~/App_Data/Templates/Voucher.html"));
    
        return Content(nvEngine.Render(htmlTemplate));
    }
