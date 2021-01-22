        public void DeleteDisconnected(Product original_entity)
        {
            var db = new RmsConcept2DataContext(base.ConnectionString);
            db.Products.Attach(original_entity, false);
            db.Products.DeleteOnSubmit(original_entity);
            db.SubmitChanges();
        }
        public void Delete(int ID)
        {
            var db = new RmsConcept2DataContext(base.ConnectionString);
            Product product = db.Products.Single(p => p.ProductID == ID);
            // delete children
            foreach (Release release in product.Releases)
                db.Releases.DeleteOnSubmit(release);
            db.Products.DeleteOnSubmit(product);
            db.SubmitChanges();
        }
