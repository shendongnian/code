public virtual TOutputDto GetOne(TKey id)
{
    var entity =
        _unitOfWork.BaseRepository
            .FindByCondition(x => 
                !x.IsDelete && 
                x.Id.Equals(id))
            .SingleOrDefault();
    if (entity == null)
    {
        throw new EntityNotFoundException();
    }
    return _dataMapper.Map<TOutputDto>(entity);
}
