                var singedUser = HttpContext.User.Identity.Name;
            try
            {
                _purchaseService.PurchaseCard(singedUser, cardName);
            }
            catch
            {
                ViewBag.ShowModal = false;
            }
