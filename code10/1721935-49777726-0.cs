    using (SqlConnection cn = new SqlConnection(_connectionString))
    {
        cn.Open();
        var predicate = Predicates.Field<SomeTable>(f => f.Id, Operator.In, commaSeparatedListOfIDs);
        IEnumerable<SomeTable> list = cn.GetList<SomeTable>(predicate);
        cn.Close();
    }
