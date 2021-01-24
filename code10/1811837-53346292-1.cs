       public async Task<IHttpActionResult> GetNotesViewModels()
        {
            var note = await GetHtmlText();
            return new HtmlActionResult(Request, note);
        }
