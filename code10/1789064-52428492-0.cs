    public void InsertPerson(float ssn, float gpa)
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
        {
            connection.Execute("EXEC [compName\\Josh].[josh_test_insert] @ssn, @gpa", new { ssn = ssn, gpa = gpa });
        }
    }
