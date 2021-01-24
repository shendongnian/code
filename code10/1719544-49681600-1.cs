    public interface IEntity
    {
        int Id { get; set; }
    }
    public class UserEntity : IEntity
    {
        private int _id;
        public int Id
        {
            get { return _id; }
        }
        int IEntity.Id
        {
            get { return _id;}
            set { _id = value; }
        }
        public string Name { get; set; }
    }
    var user = new UserEntity();
    ((IEntity)user).Id = -1;
    user.Name = "John";
    var userId = user.Id;
