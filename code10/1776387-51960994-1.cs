    var objFoo = new
    {
        balls = new Dictionary<string, Team>
        {
            {
                "a8bf081d-eaef-44db-ba25-97ed8c0b30ef",
                new Team{
                    runs=1,
                    extras=0,
                    ball_count=1,
                    wicket=0
                }
            }
        }
    };
    var result = JsonConvert.SerializeObject(objFoo);
    
