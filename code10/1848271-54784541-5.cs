                // eg: /content
                // eg: /content/product-A
                [Route("content/{productName?}")]
                public ActionResult View(string productName)
                {
                    if (!String.IsNullOrEmpty(productName))
                    {
                  productName = productName.Replace("-","").ToLower();
                  return RedirectToAction("result", new { product= productName  );
                    }
                    return View("AllProducts", GetProducts());
                }
