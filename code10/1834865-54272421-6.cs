    class Program
    {
        static void Main(string[] args)
        {
            #region Composition Root
            var entityManager = new EntityManager();
            var drawingComponentTypes = 
                new Type[] {
                    typeof(VisibleComponent),
                    typeof(PhysicalComponent) };
            var drawingSystem = new DrawingSystem(drawingComponentTypes);
            var visibleComponent =
                new PoolDecorator<VisibleComponent>(
                    new ComponentPool<VisibleComponent>(), entityManager, drawingSystem);
            var physicalComponent =
                new PoolDecorator<PhysicalComponent>(
                    new ComponentPool<PhysicalComponent>(), entityManager, drawingSystem);
            entityManager.AddSystems(drawingSystem);
            entityManager.AddComponentPool(visibleComponent);
            entityManager.AddComponentPool(physicalComponent);
            #endregion
    
            var entity = new Entity(entityManager.CreateEntity());
    
            entityManager.AddComponentToEntity(
                entity.EntityId,
                new PhysicalComponent() { X = 0, Y = 0 });
    
            Console.WriteLine($"Added physical component, number of drawn entities: {drawingSystem.SystemEntities.Count}.");
    
            entityManager.AddComponentToEntity(
                entity.EntityId,
                new VisibleComponent() { Appearance = Appearance.Monster });
    
            Console.WriteLine($"Added visible component, number of drawn entities: {drawingSystem.SystemEntities.Count}.");
    
            entityManager.RemoveComponentFromEntity<VisibleComponent>(entity.EntityId);
    
            Console.WriteLine($"Removed visible component, number of drawn entities: {drawingSystem.SystemEntities.Count}.");
    
            Console.ReadLine();
        }
    }
