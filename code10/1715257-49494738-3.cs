          // now build out the namevalue pair paramater to pass to SP call
            SqlParameter TableData = new SqlParameter();
            TableData.ParameterName = "@NameValuePairAnswers";
            TableData.TypeName = "dbo.NameValuePairTable";
            TableData.SqlDbType = SqlDbType.Structured;
            // this will be the C# object you populated from your form as a C# datatype DataTable
            TableData.Value = FormResultsDataTable; 
