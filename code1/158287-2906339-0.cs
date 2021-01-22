    catch (Exception ex)
            {
                executedSuccessfully = false;
                SqlException sqlex = ex.InnerException as SqlException;
                if (sqlex != null)
                {
                    exceptionText = sqlex.Message;
                }
            }
