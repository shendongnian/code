            // check if entity is being tracked
            var local = _context.Set<T>().Local.FirstOrDefault(x => x.Id.Equals(entity.Id));
            // if entity is tracked detach it from context
            if (local != null)
                _context.Entry<T>(local).State = EntityState.Detached;
            _context.Attach(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            // detach entity if it was not tracked, otherwise it will be kept tracking
            if(local == null)
                _context.Entry(entity).State = EntityState.Detached;
            return result > 0;
        }
