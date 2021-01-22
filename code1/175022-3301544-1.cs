    bool sawMyEx = false;
    SqlConnection cn =  null;
    SqlCommand cm = null;
    
    try
    {
        cn = new SqlConnection(connectionString);
        cm = new SqlCommand(commandString, cn);
        cn.Open();
        cm.ExecuteNonQuery();
    }
    catch (MyException myEx)
    {
        sawMyEx = true; // I better not tell my wife.
        // Do some stuff here maybe?
    }
    finally
    {
        if (sawMyEx)
        {
            // Piss my pants.
        }
        if (null != cm);
        {
            cm.Dispose();
        }
        if (null != cn)
        {
            cn.Dispose();
        }
    }
