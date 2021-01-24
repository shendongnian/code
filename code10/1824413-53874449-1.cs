        public static IObservable<IChangeSet<TDestination, TKey>> TransformWithInlineUpdate<TObject, TKey, TDestination>(this IObservable<IChangeSet<TObject, TKey>> source,
            Func<TObject, TDestination> transformFactory,
            Action<TDestination, TObject> updateAction = null)
        {
            return source.Scan((ChangeAwareCache<TDestination, TKey>)null, (cache, changes) =>
                {
                    //The change aware cache captures a history of all changes so downstream operators can replay the changes
                    if (cache == null)
                        cache = new ChangeAwareCache<TDestination, TKey>(changes.Count);
                    foreach (var change in changes)
                    {
                        switch (change.Reason)
                        {
                            case ChangeReason.Add:
                                cache.AddOrUpdate(transformFactory(change.Current), change.Key);
                                break;
                            case ChangeReason.Update:
                            {
                                if (updateAction == null) continue;
                                var previous = cache.Lookup(change.Key)
                                    .ValueOrThrow(()=> new MissingKeyException($"{change.Key} is not found."));
                                //callback when an update has been received
                                updateAction(previous, change.Current);
                                //send a refresh as this will force downstream operators 
                                cache.Refresh(change.Key);
                            }
                                break;
                            case ChangeReason.Remove:
                                cache.Remove(change.Key);
                                break;
                            case ChangeReason.Refresh:
                                cache.Refresh(change.Key);
                                break;
                            case ChangeReason.Moved:
                                //Do nothing !
                                break;
                        }
                    }
                    return cache;
                    
                }).Select(cache => cache.CaptureChanges()); //invoke capture changes to return the changeset
        }
