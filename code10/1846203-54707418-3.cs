    [Route("~/file/{id}")]
    public async Task<IActionResult> File(int id)
    {
        FileViewModel m = await LoadFileAsync(id).ConfigureAwait(false);
        m.Title = m.Title.Normalize(NormalizationForm.FormC);
        return View(m);
    }
