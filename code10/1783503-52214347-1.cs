            public List<Models.ObjectModel> GetAll()
        {
            //return _db.Object
            //    .Include(o => o.ObjectTags)
            //    .ThenInclude(ot => ot.Tag)
            //    .ToList();
            return _db.Object
                .Include(o => o.ObjectTags)
                .ThenInclude(ot => ot.Tag)
                .Select(r => new Models.ObjectModel
                {
                    ObjectId = r.ObjectId,
                    Name = r.Name,
                    Tags = r.ObjectTags.Select(ot => ot.Tag).ToList()
                })
                .ToList();
        }
