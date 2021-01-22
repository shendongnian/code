    IList<BallViewModel> _balls = _ballsService.GetBalls(searchCriteria)
        .Select(b => new BallsViewModel
                     {
                         ID = b.ID,
                         Name = b.Name,
                         // etc
                     })
        .ToList();
