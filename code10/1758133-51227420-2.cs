    public class EntityService
    {
        ...
        public async Task Create(CreateEntityModel model)
        {
            var entity = new Entity
            {
                X = model.X...
            };
            await entityRepository.Create(entity);
        }
    }
