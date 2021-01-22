    public IQueryable<T> GetList<T>( bool activeOnly ) where T : class, IReferenceData
    {
         return this.GetTable<T>()
                    .Where( b => !activeOnly || b.isActive )
                    .OrderBy( c => c.Title );
    }
