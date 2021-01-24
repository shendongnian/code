     public JsonResult ProductAutocompleteByCode(string code)
        {
            var products = Json(db.Products.Where(p => p.code.Contains(code)).Select(p => new ProductDTO { Id = p.id, Code = p.code, Name = p.name, Price= p.price }));
            return Json(products.Data, JsonRequestBehavior.AllowGet);
        }
