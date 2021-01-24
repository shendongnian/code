     public class PlayerController : Controller
        {
            public ActionResult Index1()
            {
                BasketDbContext db = new BasketDbContext();
                List<Player> playerList = db.Player.ToList();
                PlayerIndex1Model playerVM = new PlayerIndex1Model();
                List<PlayerIndex1Model> playerVMList = playerList.Select(x => new PlayerIndex1Model
                {
                    PlayerName = x.PlayerName,
                    Id = x.Id,
                    PlayerHeight=x.PlayerHeight,
                    PlayerSurname=x.PlayerSurname,
                    PlayerPosition=x.PlayerPosition,
                    Birthday=x.Birthday,
                    
                    PlayerWeight=x.PlayerWeight,
                    BasketBallClubId = x.BasketballClubId,
                    ClubName = x.BasketballClub.ClubName
                                      
                }).ToList();
                return View(playerVMList);
            }
