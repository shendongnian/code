    //..
    case EntityState.Deleted:
        entry.State = EntityState.Modified;
        entry.CurrentValues["IsDeleted"] = true;
        foreach (var navigationEntry in entry.Navigations.Where(n => !n.Metadata.IsDependentToPrincipal()))
        {
            if (navigationEntry is CollectionEntry collectionEntry)
            {
                foreach (var dependentEntry in collectionEntry.CurrentValue)
                {
                    HandleDependent(Entry(dependentEntry));
                }
            }
            else
            {
                var dependentEntry = navigationEntry.CurrentValue;
                if (dependentEntry != null)
                {
                    HandleDependent(Entry(dependentEntry));
                }
            }
        }
        break;
    }
    
    private void HandleDependent(EntityEntry entry)
    {
        entry.CurrentValues["IsDeleted"] = true;
    }
