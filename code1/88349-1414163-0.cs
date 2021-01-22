    public IQueryable<T> GetList<T>( bool activeOnly ) where T : IReferenceData
    {
         return this.GetTable( typeof(T) ) )
                    .Where( b => !activeOnly || b.isActive )
                    .OrderBy( c => c.Title );
    }
           
