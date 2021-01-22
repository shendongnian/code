            public ActionResult Form()
            {
                ... /* Declare viewData etc. */
                if (TempData["form"] != null)
                {
                    viewData.Form.SetValues((System.Collections.Specialized.NameValueCollection)TempData["form"]);
                    viewData.Form.Validate();
                }
                return View("Form", viewData);
            }
