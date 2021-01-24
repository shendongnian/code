        public Task<Class> GetDetailsById(int id)
        {
            var singleClass = db.Classes
                .Include(f=>f.ClassDetailListing)
                .FirstOrDefault(d => d.Id == id);
            return Task.Run(() => singleClass);
        }
        public Task<List<ClassDetail>> GetClassDetailsById(int classId)
        {
            var listings = db.ClassDetails
                .Include(f=>f.ClassInfo)
                .Where(d => d.ClassId == classId)
                    .ToList();
            return Task.Run(() => listings);
        }
