    [HttpPost("{id}")]
    public async Task<ActionResult<bool>> Update(string id, Model model)
    {
        await leaveService.AddReplacement(id, model.AdditionalDays);
        return true;
    }
