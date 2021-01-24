    public async Task<IEnumerable<PostCount>> AllTags()
    {
        var tags = await _context.Tags.Select(a => new PostCount
        {
            Name = a.Name,
            Count = a.PostTags.Count()
        }).ToListAsync();
            
        return View(tags);
    }
