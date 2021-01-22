    [ServiceContract]
    interface IEntity1Services
    { 
        [OperationContract]
        void Insert(Entity1 newEntity);
        [OperationContract]
        void Delete(Entity1 entityToDelete);
        [OperationContract]
        List<Entity1> GetAll();
        [OperationContract]
        Entity1 GetById(int id);
    }
    [ServiceContract]
    interface IEntity2Services
    { 
        [OperationContract]
        void AddSomething(Entity2 entity);
        [OperationContract]
        void RemoveSomething(Entity2 entity);
        [OperationContract]
        SelectSomething(Entity2 entity);
    }
