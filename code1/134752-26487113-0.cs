            rowsCount = obj.Count();
            int innerRows = rowsCount - (page * pageSize);
            if (innerRows < 0)
            {
                innerRows = 0;
            }
            if (asc)
                return obj.OrderByDescending(keySelector).Take(innerRows).OrderBy(keySelector).Take(pageSize).AsQueryable();
            else
                return obj.OrderBy(keySelector).Take(innerRows).OrderByDescending(keySelector).Take(pageSize).AsQueryable();
        }
