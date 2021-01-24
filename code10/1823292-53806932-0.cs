    Enemy[] enemies = someObject.GetComponentsInChildren<Enemy>();
    foreach (Enemy e in enemies)
    {
        if e.GetType() == objectInQuestion.GetType()
        {
            DoAThing(e); // Or add e to a list or whatever
        }
    }
