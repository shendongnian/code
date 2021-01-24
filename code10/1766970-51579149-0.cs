        public IActionResult Post(Cart cart)
        {
            if (ModelState.IsValid)
            {
                Session["cart"].Add(
                    new Cart
                    {
                        CartId = cart.CartId,
                        FoodId = cart.FoodId,
                        FoodName = cart.FoodName,
                        quantity = cart.quantity,
                        price = cart.price
                    });
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
