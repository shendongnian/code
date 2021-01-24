    public async Task<ActionResult> Index()
    {
        var awardWinners = await awardWinnersService.GetAwardWinnersAsync();
        var viewModel = new AwardWinnersWrapperVM
        {
            AwardWinners = awardWinners.Select(x => new AwardWinnersViewModel
            {
                AwardId = x.AwardId
            })
        };
        return View(awardWinners);
    }
