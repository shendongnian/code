    var ballQuery = from ball in _ballsService.GetBalls(searchCriteria)
                    select new BallViewModels
                    {
                        Diameter = ball.Diameter,
                        color = ball.Color,
                        ...
                    }
    IList<BallViewModels> _balls = ballQuery.ToList();
