    public virtual void Create(TDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException("dto");
        }
        var entity = _mapper.Map<TEntity>(dto);
        _repository.Add(entity);
        _unitOfWork.Commit();         
    }
