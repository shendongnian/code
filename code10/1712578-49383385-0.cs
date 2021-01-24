    public static async Task<bool> IsEntityCheckedOut(ProjectEntities _context, object _entity)
        {
            var bCheckedOut = false;
            await _context.Entry(_entity).ReloadAsync().ContinueWith(x =>
            {
                if (!x.IsFaulted)
                {
                    var _baseentity = _entity as TblBase;
                    if (_baseentity.COID.GetValueOrDefault() != 0)
                    {
                        Console.WriteLine("Assigned");
                        bCheckedOut = true;
                    }
                    else
                    {
                        Console.WriteLine("Not Assigned");
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return bCheckedOut;
        }
