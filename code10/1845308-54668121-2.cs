    var tasks = dt.AsEnumerable().Select(row => Task.Run(() =>
        {
            try
            {
                // some http call
            }
            catch (Exception ex)
            {
                // rewrap the needed information into your custom exception object
                throw YourException(ex, row["ssub_msisdn"]);
            }
        });
    // now you are at the UI thread
    foreach (var t in tasks)
    {
        try
        {
            await t;
        }
        catch (YourException ex)
        {
            AppendTextBox(ex.SsubMsisdn + ", Error: " + ex.InnerException.Message, txtBoxResponse);
        }
    }
