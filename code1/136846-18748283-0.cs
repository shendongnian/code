    // Let's detour DateTime.Now
    MDateTime.NowGet = () => new DateTime(2000,1, 1);
    if (DateTime.Now == new DateTime(2000, 1, 1);
    {
        throw new Exception("Wahoo we did it!");
    }
