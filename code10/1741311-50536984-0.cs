    public class GamesNightAttendance
    {
        public int Id { get; set; }
        // add missing foreign key
        public int GameNightId { get; set; }
        // add missing foreign key
        public int UserId { get; set; }
        public virtual GamesNight GameNight { get; set; }
        // fix name
        public virtual ApplicationUser User { get; set; }
    }
