    public virtual Task<IdentityResult> DeleteAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
    
            return Store.DeleteAsync(user, CancellationToken);
        }
