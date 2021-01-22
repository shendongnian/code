    class SqlParameterOption
     {
        public SqlParameterOption Precision(int p) {/* ... */; return this;}
        public SqlParameterOption Substitute() {/* ... */; return this;}
        /* ... */       
     }
    /* ... */
    SqlParameter.Int32(":ID", 1234).With(new SqlParameterOption()
                                               .Precision(15)
                                               .Substitute());
    
