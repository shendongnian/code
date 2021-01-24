        public static Expression<Func<Child, ChildDTO>> DefaultColumns {
            get {
                return c => new ChildDTO() {
                    Id = c.Id,
                    Address = c.Address,
                    ...
                };
            }
        }
        db.Children.Select(DefaultColumns);
