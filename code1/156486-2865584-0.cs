        Product prod = entities
                .Product.Include("Rating")
                .First(p => p.product_id == pid);
        if (prod.Rating != null)
        {
            log.Info("Rating already exists!");
            // set values and Calcuate the score
        }
        else
        {
            log.Info("New Rating!!!");
            Rating rating = new Rating();
            // set values and do inital calculation
            prod.Rating = rating;
        } 
        entities.SaveChanges();
