        public async Task<List<TimeAndAttendanceShift>> FindEntitiesByExpression(Expression<Func<TimeAndAttendanceShift, bool>> predicate)
        {
            IList<TimeAndAttendanceShift> result = await _dbContext.Set<TimeAndAttendanceShift>().Where(predicate).ToListAsync<TimeAndAttendanceShift>();
            return result.ToList<TimeAndAttendanceShift>();
        }
