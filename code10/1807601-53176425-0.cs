     public async Task<Result> GenerateCombinationByAttributesList(List<Guid> attributeIds)
        {
            var result = new Result();
            await semaphoreSlim.WaitAsync();
            try
            {
                DoHeavyStuffHere();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.SetError(ex.Message);
            }
            finally
            {
                semaphoreSlim.Release();
            }
            return result;
        }
