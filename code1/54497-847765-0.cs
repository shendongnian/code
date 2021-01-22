    catch(System.Data.SqlClient.SqlException lExSql)
    {
        if(lExSql.Number == 2601)
            return Result.Duplicate;
        else
            return Result.Failure;
    }
    catch
    {
        return Result.Failure;
    }
