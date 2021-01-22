public virtual TOutputDto GetOne(TKey id)
{
    var entity =
        _unitOfWork.BaseRepository
            .FindByCondition(x => 
                !x.IsDelete && 
                x.Id.Equals(id))
            .SingleOrDefault();
    // ...
}
