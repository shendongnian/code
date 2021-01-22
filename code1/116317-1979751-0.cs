    public static IEnumerable<T> NotNullEnum<T>( this IEnumerable<T> o ) {
        if ( object.ReferenceEquals( o, null ) {
            return new T[0];
        }
        else {
            return o;
        }
    }
    
    IQueryable<mContract> query2 = this.ObjectContext.mContract.NotNullEnum().Where(
            q => q.wEmpId == empId && q.wEmpId == "NOTVALID");
    var count = query2.Count();
