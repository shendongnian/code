    [HttpPost]
            public ActionResult Index(YourViewModel model)
            {
                #region backend validation
    
                if (
                    !GoogleReCAPTCHAHelper.Check(Request["g-recaptcha-response"],
                        ConfigurationManager.AppSettings["GoogleReCAPTCHASecret"]))
                {
                    ModelState.AddModelError(string.Empty, "You have to confirm that you are not robot!");
                    return View(model);
                }
    
                if ((from file in model.Files where file != null select file.FileName.Split('.')).Any(arr => arr[arr.Length - 1].ToLower() != "pdf"))
                {
                    ModelState.AddModelError(string.Empty, "We only accept PDF files!");
                    return View(model);
                }
                if (model.Files.Count() > 2)
                {
                    ModelState.AddModelError(string.Empty,
                        "You have exceeded maximum file upload size. You can upload maximum 2 PDF file!");
                    return View(model);
                }
    
                //// this stops the applicant sending the application multiple times within 5 minutes of a submition
                DateTime? lastSubmission = null;
                if (Request.Cookies["LastSubmission"] != null)
                    lastSubmission = Convert.ToDateTime(Request.Cookies["LastSubmission"].Value);
                if (lastSubmission.HasValue && DateTime.Now < lastSubmission.Value.AddMinutes(5))
                {
                    ModelState.AddModelError(string.Empty,
                        "ERROR: Your application has not been sent. This is due to receiving an application from you within the last five minutes. If you have made an error and wish to resend your application, please wait five minutes and then complete the application again.");
                    return View(model);
                }
    
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!");
                    return View(model);
                }
    
                #endregion
    }
