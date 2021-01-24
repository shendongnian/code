            public async Task<IActionResult> DbQuery()
        {
            var result = await _context.Query<TableNotInDbContext>()
                                       .FromSql($"Select * From PersonNotInDbContext")
                                       .ToListAsync();
            return Ok(result);
        }
