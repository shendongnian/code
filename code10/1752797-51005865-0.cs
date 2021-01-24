    public static class CompanyExtensions{
        public static CompanyDto ToDto( this Company me ){
            return new CompanyDto{
                ID = me.Id, 
                ...the rest of the fields.
            }
        }
    }
