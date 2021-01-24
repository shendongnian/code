    public Task<IHttpActionResult> DoStuff()
    {
        await Task.WhenAll(groups.Select(g =>
                         ledgerService.CreateItemsAsync(g.GLAccountingHeaderId));
        return StatusCode(HttpStatusCode.NoContent);
    }
