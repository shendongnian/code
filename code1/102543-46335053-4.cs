    using testdemo.Models
    
    public ActionResult Index() {
                return View();
            }
            [HttpPost]
            public ActionResult Index(string text)
            {
                if (Request["txtEncrypt"] != null)
                {
                    string getEncryptionCode = Request["txtEncrypt"];
                    string DecryptCode = Encryption.Decrypt(HttpUtility.UrlDecode(getEncryptionCode));
                    ViewBag.GetDecryptCode = DecryptCode;
                    return View();
                }
                else {
                    string getDecryptCode = Request["txtDecrypt"];
                    string EncryptionCode = HttpUtility.UrlEncode(Encryption.Encrypt(getDecryptCode));
                    ViewBag.GetEncryptionCode = EncryptionCode;
                    return View();
                }
    
            }
