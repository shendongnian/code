    catch(FileNotFoundException fnfExc)
    {
        Logger.Log(fnfExce.Message, CategoryEnum.DiskError);
    }
    catch(FilePermissionError permExc)
    {
        Logger.Log(permExc.Message, CategoryEnum.DiskError);
    }
    catch(Exception exc)  { //catches anything else not caught above
        Logger.Log(exc.Message, CategoryEnum.Uknown);
    }
