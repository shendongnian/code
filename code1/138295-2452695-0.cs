    public void SaveOrUpdate(T productDetail) 
    {             
        using (ITransaction tx = _session.BeginTransaction()) 
        { 
            ProductDetailBook bookDetail = productDetail as ProductDetailBook;
            if (bookDetail != null)
               _repo.SaveOrUpdate(bookDetail); 
            tx.Commit(); 
        } 
    } 
