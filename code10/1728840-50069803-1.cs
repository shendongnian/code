     [HttpGet]
            public IActionResult OpretLobby()
            {
                return View("OpretLobby");
            }
            [HttpPost]
            public IActionResult OpretLobby(LobbyViewModel lobby)
            {
                
                try
                {
                    //find brugeren der har lavet lobby
                    var currentUser = _userSession.User;
                    //save as a lobby
                    ILobby nyLobby = new Lobby(currentUser.Username)
                    {
                        Id = lobby.Id
                    };
                    //SessionExtension.SetObjectAsJson(HttpContext.Session, lobby.Id, nyLobby);
                    //add to the list
                    _lobbyList.Add(nyLobby);
                    return RedirectToAction("Lobby","Lobby",lobby);
                }
                catch (ArgumentException)
                {
                    return RedirectToAction("OpretLobby");
                }
                
            }
