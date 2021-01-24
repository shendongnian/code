    class Program
    {
        static void Main(string[] args)
        {
            var searchList = new List<TwoProps>()
            {
                new TwoProps() {Name = "sdfs1", PatientEmail="mymail@sf.com" },
                new TwoProps() {Name = "sdfs2", PatientEmail=null },
                new TwoProps() {Name = "sdfs3", PatientEmail="mymail2@sf.com" }
            };
    
            var stringToSearch = "myMail".ToLower();
            var query = (from listItem in searchList
                        where listItem.Name.ToLower().Contains(stringToSearch)
                            || listItem.PatientEmail.ToLower().Contains(stringToSearch)
                        select listItem).ToList(); //NullReferenceException is thrown here @ second element
            //listItem.PatientEmail.ToLower() => null.ToLower() => NRE
        
            Console.WriteLine(query.Count());
        }
    
        private class TwoProps
        {
            public string Name { get; set; }
            public string PatientEmail { get; set; }
        }
    }
