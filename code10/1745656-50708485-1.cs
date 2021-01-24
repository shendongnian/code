    var sync = new object();
    Parallel.ForEach(kiosks, kiosk => {
        //collecting kiosk info from db
        DashboardViewModel mykiosk = new DashboardViewModel(kiosk);
        mykiosk.kioskAlliveTime = kiosk.System_State_Monitor_Kiosk.Alive_Time;
        //filling all instances of mykiosk into mykiosks list
        lock(sync)
        {
            mykiosks.Add(mykiosk);
        }
    });
