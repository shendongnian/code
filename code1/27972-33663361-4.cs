    [SubmitActionToThisMethod]
    public async Task<ActionResult> FundDeathStar(ImperialModel model)
    {
        await TrainStormTroopers();
        return View();
    }
    [SubmitActionToThisMethod]
    public async Task<ActionResult> HireBoba(ImperialModel model)
    {
        await RepairSlave1();
        return View();
    }
