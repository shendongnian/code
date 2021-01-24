    public class NewTaskDto {
        [Required]
        public string Title { get; set; }
        public virtual UserDto User { get; set; }
    }
    
    public class UserDto {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
