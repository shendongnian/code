        public class DevDto
        {
            //Null-exception check
            public DevDto()
            {
                Tags = new List<Tags>();
            }
            public byte Id { get; set; }
            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }
            public string Email { get; set; }
            public ICollection<Tags> Tags { get; set; }
        }
