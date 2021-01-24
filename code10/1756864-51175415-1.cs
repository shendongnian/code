    public bool insertRowIntoApplicant(int? ansId, string Name)
    {
        string CS = Utilities.GetConnString();
        using (SqlConnection con = new SqlConnection(CS))
        {
           SqlCommand cmd = new SqlCommand("Insert Into ApplicantTable(AnswerableId,Name) values(@AnsId,@Name);
           SqlParameter paraAnsId = new SqlParameter()
            {
                ParameterName ="@AnsId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (object)ansId ?? DBNull.Value
            };
            // initialize paraName
            cmd.Parameters.Add(paraAnsId);
            cmd.Parameters.Add(paraName);
        }
    }
