    Int32 Cost = 0;
    SQLCommand sqlcmd = New SQLCommand(SELECT [Cost] from [Cars] WHERE ([RegistrationNumber] = @RegistrationNumber), connection);
    sqlcmd.Parameters.Add("@RegistrationNumber", SqlDbType.VarChar).Value = RegNumber;
            try
        {
            conn.Open();
            Cost = (Int32)sqlcmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
