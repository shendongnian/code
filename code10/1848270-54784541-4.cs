         // eg: /content
        // eg: /content/product-A
        [Route("content/{productName?}")]
        public ActionResult View(string productName)
        {
            if (!String.IsNullOrEmpty(productName))
            {
                return View("ViewProduct", GetProduct(productName));
            }
            return View("AllProducts", GetProducts());
        }
