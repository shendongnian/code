    public bool DeleteGallery(int id)
    {
        try
        {
            using (var transaction = new DbTransactionManager())
            {
                try
                {
                    transaction.BeginTransaction();
    
                    _galleryRepository.DeleteGallery(id, transaction);
                    _galleryRepository.DeletePictures(id, transaction);
    
                    FileManager.DeleteAll(id);
    
                    transaction.Commit();
                }
                catch (DataAccessException ex)
                {
                    Logger.Log(ex);
                    transaction.Rollback();                        
                    throw new BusinessObjectException("Cannot delete gallery. Ensure business rules and try again.", ex);
                }
            }
        }
        catch (DbTransactionException ex)
        {
            Logger.Log(ex);
            throw new BusinessObjectException("Cannot delete gallery.", ex);
        }
        return true;
    }
