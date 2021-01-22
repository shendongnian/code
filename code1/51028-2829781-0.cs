    public override void Dispose()
    {
        base.Dispose();
        DisposeOf<UserTableAdapter>(ref userAdapter);
        DisposeOf<ProductsTableAdapter>(ref productsAdapter);
        if (connection != null)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            DisposeOf<SqlConnection>(ref connection);
        }
    }
    private void DisposeOf<T>(ref T objectToDispose) where T : IDisposable
    {
        if (objectToDispose != null)
        {
            objectToDispose.Dispose();
            objectToDispose = default(T);
        }
    }
