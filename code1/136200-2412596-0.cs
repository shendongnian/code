        public class Entity
        {
            public decimal Amount { get; set; }
            public decimal OtherAmount { get; set; }
        }
        public static void Update<TEntity, TValue>(this IEnumerable<TEntity> entities, Func<TValue> valueGetter, Action<TEntity, TValue> valueSetter)
        {
            foreach (TEntity entity in entities)
            {
                TValue value = valueGetter.Invoke();
                valueSetter.Invoke(entity, value);
            }
        }
        public static decimal GetAmount()
        {
            throw new NotImplementedException();
        }
        public static decimal GetOtherAmount()
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }
        static void Main()
        {
            IEnumerable<Entity> entities = GetEntities();
            entities.Update<Entity, decimal>(GetAmount, (entity, value) => entity.Amount = value);
            entities.Update<Entity, decimal>(GetOtherAmount, (entity, otherValue) => entity.OtherAmount = otherValue);
        }
