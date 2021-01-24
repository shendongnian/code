    // GET: api/UserPwordHints/5
    [ResponseType(typeof(UserPwordHintsModels)), HTTPGet]
    public async Task<IHttpActionResult> GetUserPwordHintsModels(string id)
    
    // PUT: api/UserPwordHints/5
    [ResponseType(typeof(void)), HTTPPut]
    public async Task<IHttpActionResult> PutUserPwordHintsModels(string id, 
    UserPwordHintsModels userPwordHintsModels)
