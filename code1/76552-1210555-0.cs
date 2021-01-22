     // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            var conversationToView = (from c in _entities.conversation
                                      where c.conversation_id == id
                                      select c).FirstOrDefault();
            return View(conversationToView);
        }
