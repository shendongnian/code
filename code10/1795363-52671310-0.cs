    public async Task<int> GetCountAllParticipants()
    {
        return await context.Participants.CountAsync();
    }
    [HttpGet("all/count")]
    public async Task<JsonResult> GetCountAllParticipants()
    {
        return Json(await repo.GetCountAllParticipants());
    }
