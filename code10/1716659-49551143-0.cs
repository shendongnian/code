    private async static Task<bool> RefreshLinesAsync<TEntity>(LocalUser ThisUser, ProjectEntities DBContext, TEntity Entity) where TEntity : TblBase
    {
        List<TEntity> NonExistingNodes = new List<TEntity>();
        var bContinue = false;
        var PassedEntity = Entity as TblBase;
        foreach (var SubEntity in DBContext.Set<TEntity>().Where(x => (x as TblBase).ProjectID == PassedEntity.ID).ToList()) {
           //Your other code here...
        }
    }
