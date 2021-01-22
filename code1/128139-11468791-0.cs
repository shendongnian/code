    public class EntityBase : IEntityBase
    {
        /// <summary>
        /// Detaches the entity, so it can be added to another dataContext. It does this by setting
        /// all the FK properties to null/default.
        /// </summary>
        public void Detach()
        {
            // I modified the .tt file to generate the Initialize method by default. 
            // The call to OnCreated() is moved to the constructor.
            GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, null);
        }
    }
