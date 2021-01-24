    bool TryAddToDestination<T>(object o)
    {
        if (o is ObservableCollection<T> sourceCollection)
        {
           var destinationCollection = GetDestination (sourceCollection);
           destinationCollection?.Clear();
           destinationCollection?.AddRange(sourceCollection);
           return true;
        }
        return false;   
    }
    void YourFunction()
    {
        TryAddToDestination<Guid> || TryAddToDestination<AViewModel> || TryAddToDestination<BViewModel> || TryAddToDestination<CViewModel);
    }
