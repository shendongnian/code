    [HttpPost]
        public ActionResult GetNewCardEdipi(string name)
        {
            //test multiple readers
            X509Store keystore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            keystore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var clientCert = keystore.Certificates;
            var certs = keystore.Certificates.Find(X509FindType.FindBySubjectName, name, false);
            var cuser = certs[0];
            var sub = cuser.Subject;
            string[] strs = sub.Split(',');
            string edi = strs[0].Substring(strs[0].LastIndexOf(".") + 1);
            //end
            return Json(edi);
        }
