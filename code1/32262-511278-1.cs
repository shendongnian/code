    private DbProviderFactory GiveMeSomeFactory()
    {
        if(something)
            return SqlClientFactory.Instance;
        else if(somethingElse)
            return OracleFactory.Instance;
        else if(notThisAndNotThat)
            return MySqlFactory.Instance;
        else
            return WhateverFactory.Instance;
    
    }
