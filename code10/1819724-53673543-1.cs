    public abstract class UserInfo
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
    
        [NotMapped]
        public string FriendlyIdentifier
        {
            get
            {
                var name = $"{Name} {Surname}";
                if (!string.IsNullOrWhiteSpace(name))
                    return name;
                else if (!string.IsNullOrWhiteSpace(Email))
                    return Email;
                else
                    return UserId.ToString();
            }
        }
    
        public ICollection<Booking> Bookings { get; set; }
    }
    
    public class User : UserInfo { }
    
    public class UserDetails : UserInfo
    {
        public DateTime? LatestBookingDate { get; set; }
    }
