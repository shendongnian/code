    public interface IEntity
    {
        int Id { get; set; }
    }
    public class UserEntity : IEntity
    {
        int IEntity.Id { get; set; }
        public string Name { get; set; }
    }
    var user = new UserEntity();
    ((IEntity)user).Id = -1;
    user.Name = "John";
