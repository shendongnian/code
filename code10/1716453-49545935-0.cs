        public async Task<IEnumerable<UserEditorViewModel>> GetAllWithRoles() {
            return await _dbSet
                .AsNoTracking()
                .SelectMany(u => u.UserRoles)
                .Select(ur => new UserEditorViewModel {
                    FirstName = ur.User.FirstName,
                    LastName = ur.User.LastName,
                    RoleName = ur.Role.Name
                })
                .ToListAsync();
        }
