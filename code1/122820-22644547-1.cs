    private pricecheckEntities _context = new pricecheckEntities();
     private void resetpcheckedtoFalse()
        {
            try
            {
                foreach (var product in _context.products)
                {
                    product.pchecked = false;
                    _context.products.Attach(product);
                    _context.Entry(product).State = EntityState.Modified;
                }//<---------
                _context.SaveChanges();
            }
            catch (Exception extofException)
            {
                MessageBox.Show(extofException.ToString());
            }
            productsDataGrid.Items.Refresh();
        }
