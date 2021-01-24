    public Task RenewAsync(string key, AuthenticationTicket ticket)
            {
                var options = new DistributedCacheEntryOptions();
                var expiresUtc = ticket.Properties.ExpiresUtc;
                if (expiresUtc.HasValue)
                    options.SetAbsoluteExpiration(expiresUtc.Value);
    
                if (ticket.Properties.IsPersistent && !expiresUtc.HasValue)
                    options.SetSlidingExpiration(_rememberMeTimeoutInDays);
                else if (ticket.Properties.IsPersistent && expiresUtc.HasValue)
                    options.SetSlidingExpiration(TimeSpan.FromTicks(expiresUtc.Value.Ticks));
                else
                    options.SetSlidingExpiration(_defaultTimeoutInHours);
    
                byte[] val = SerializeToBytes(ticket, _logger);
                _cache.Set(key, val, options);
                return Task.FromResult(0);
            }
