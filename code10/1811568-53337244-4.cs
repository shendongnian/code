        public void AddToCart(int value)
        {
            if (ModelState.IsValid)
            {
                //here is some code
            }
        }
    
    **TO**
      [HttpPost]
      public void AddToCart(int value)
        {
            if (ModelState.IsValid)
            {
                //here is some code
            }
        }
