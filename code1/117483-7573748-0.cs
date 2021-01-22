    using (var session = NHibernateHelper.OpenSession ())
    using (var transaction = session.BeginTransaction ()) {
        using (var cmd = new SqlCommand ()) {
            transaction.Enlist (cmd);
            var bulk = new SqlBulkCopy ((SqlConnection)session.Connection,
                                        SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers,
                                        (SqlTransaction)cmd.Transaction);
        }
        // ...
        transaction.Commit ();
    }
