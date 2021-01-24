    public void DeleteMyEntity(MyEntity entity)
            {
                var target = MyEntities
                    .Include(x => x.Children)
                    .FirstOrDefault(x => x.Id == entity.Id);
    
                RecursiveDelete(target);
    
                SaveChanges();
    
            }
    
            private void RecursiveDelete(MyEntity parent)
            {
                if (parent.Children != null)
                {
                    var children = MyEntities
                        .Include(x => x.Children)
                        .Where(x => x.ParentId == parent.Id);
    
                    foreach (var child in children)
                    {
                        RecursiveDelete(child);
                    }
                }
    
                MyEntities.Remove(parent);
            }
