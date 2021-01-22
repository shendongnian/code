        return (
                from c in _entity.Category
                orderby c.Id descending
                select new CategoryDto
                {
                    Id = c.Id,
                    Name =  c.Name,
                    Items = (
                        from i in c.Items
                        order by i.Id descending
                        select new ItemSummary
                        {
                            // Assignment stuff
                        }
                    )
                }).ToList();
