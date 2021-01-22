    public class Impersonate : CallTarget
    {
        public string Domain { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public override bool Execute()
        {
            using (new Impersonator(this.UserName, this.Domain, this.Password))
            {
                return base.Execute();
            }
        }
    }
