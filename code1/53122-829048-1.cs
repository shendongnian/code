        class UserHour
        {
            public string Name {get;set;}
            public int Id { get; set; }
            public string Hour { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var users = new List<UserHour>
                            {
                                        new UserHour {Name = "Fred", Id = 1, Hour = "0800"},
                                        new UserHour {Name = "Fred", Id = 1, Hour = "0900"},
                                        new UserHour {Name = "Fred", Id = 1, Hour = "1000"},
                                        new UserHour {Name = "Bob", Id = 2, Hour = "0900"},
                                        new UserHour {Name = "Bob", Id = 2, Hour = "1000"},
                            };
            var result = from x in users
                         group x by x.Hour
                         into hour select new
                                              {
                                                          hourStr = hour.Key, hourUsers = hour
                                              };
            myGrid.DataSource = result;
            myGrid.DataBind();
        }
