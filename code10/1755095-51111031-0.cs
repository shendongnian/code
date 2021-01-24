    public override Task<MyDto> Create(MyCreateDto input)
    {
        try
        {
            var dto = base.Create(input);
            _unitOfWorkManager.Current.SaveChanges();
            return dto;
        }
        catch (DbUpdateException ex)
        {
            throw new UserFriendlyException("A message for the user");
        }
    }
