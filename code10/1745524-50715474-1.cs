            if (int.TryParse(Request.Form["add"], out int selectedProductId))
            {
                Product selectedProduct = myRepository.Products.Where(p => p.ProductID == selectedProductId).FirstOrDefault();
                if (selectedProduct != null)
                {
                    SessionHelper.GetCart(Session).AddItem(selectedProduct, 1);
                    SessionHelper.Set(Session, SessionKey.RETURN_URL, Request.RawUrl);
                    Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath);
                }
            }
