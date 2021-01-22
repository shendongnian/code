    using(SQLConnection conn = 'connection string here')
    {
        using(SQLCommand cmd = new ('sql query', conn))
        {
            //execute it blah blah
        }
    }
