    public partial class Questions
        {
            public int id { get; set; }
            public int registrationId { get; set; }
            public string Title { get; set; }
            public string Data { get; set; }
        }
    
        public partial class Registrations
        {
            public Registrations()
            {
                this.Questions = new HashSet<Questions>();
            }
    
            public int id { get; set; }
            public virtual ICollection<Questions> Questions { get; set; }
            public bool HasCity(string titleCity)
            {            
                if (this.Questions.Any(x => x.Title.ToLower() == titleCity.ToLower()))
                {
                    return true;
                }
                return false;
            }
        }
