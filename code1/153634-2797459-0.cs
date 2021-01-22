    IEnumerable<DataContract.Widget> GetMany( 
        Func<DataContract.Widget, bool> predicate) 
    { 
        // get Widgets
        IQueryable<DataContract.Widget> qry = dc.Widgets.Select(w => TODO: CONVERT_TO_ActiveRecord.Widget);
    
        return qry.Where(predicate);
    }
