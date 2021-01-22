    interface IIsActive {
        bool IsActive { get; set; }
    }
    class A : IIsActive {
        public bool IsActive { get; set; }
    }
    class B : IIsActive {
        public bool IsActive { get; set; }
    }
    public IList<T> GetAllActive() where T : IIsActive{
        return dataContext.GetTable<T>()
                          .Where(x => x.IsActive)
                          .ToList();
    }
