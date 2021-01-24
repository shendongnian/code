    // [UnitOfWork(IsDisabled = true)]
    public async Task<TagDto> CreateTag(CreateTagInput input)
    {
        var existing = await _tagsManager.Tags.Where(p => p.Type == input.Type && p.Value == input.Value.Trim()).FirstOrDefaultAsync();
        if (existing != null) throw new UserFriendlyException(L("ExistedRepeatedTag"));
        var newEntity = ObjectMapper.Map<Tag>(input);
        await _tagsManager.CreateTag(newEntity);
        // await _unitOfWorkManager.Current.SaveChangesAsync();
        await CurrentUnitOfWork.SaveChangesAsync();
        return ObjectMapper.Map<TagDto>(newEntity);
    }
