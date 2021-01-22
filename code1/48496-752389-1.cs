    private void IsValid() { return (someCondition && unpredictableThing == 5); }
    /* ... */
    private void ConsiderTheOstrich()
    {
        /* do ostrich things */
        if(IsValid())
            return true;
        else
            return false; // ostrichlogger logs it for us now
    }
