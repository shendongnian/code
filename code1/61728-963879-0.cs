    private void Save(Product product)
    {
        try
        {
            product.Save();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            throw;
        }
    }
