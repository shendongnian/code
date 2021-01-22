    using (var connection = SomeMethodThatCreatesAConnectionObject())
    {
        // do your stuff here
        connection.Close(); // this is not necessary as
                            // Dispose() closes it anyway
                            // but still nice to do.
    }
