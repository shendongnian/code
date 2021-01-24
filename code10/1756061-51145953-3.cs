                // GetById now requires an IExpressionKeyEntity to be retrieved
                public async Task<TEntity> GetById<TEntity>(int id)
                    where TEntity : IExpressionKeyEntity
                {
                    // Return the first match based on our func
                    return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefault(q => q.HasMatchingId(id));
                }
