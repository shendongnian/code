    [HttpPost("{id}")]
    public async Task<ActionResult<bool>> Update(string id, [FromBody] Model model)
    {
        await leaveService.AddReplacement(id, model.AdditionalDays);
        return true;
    }
