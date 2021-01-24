    public ActionResult Details(int? id)
        {    
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            game.Reviews = db.Reviews.Where(r => r.GameId == game.Id).ToList();            
            return View(game);
        }
