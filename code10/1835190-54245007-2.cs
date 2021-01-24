    int? Q3 = null;
    Q3 = CheckNumericContent(r, dr, "Q3"); //Q3 empty cell for the row in csv.
    if (Q3.HasValue)
    {
        sqlParams.Add("@Q3", Q3);
    }
    else
    {
        sqlParams.Add("@Q3", DBNull.Value)
    }
    sql.ExecStoredProcedureDataTable("[spInsert_Data]", sqlParams);
