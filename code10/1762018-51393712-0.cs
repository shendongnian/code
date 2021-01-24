    List<System.Timers.Timer> timers = new List<System.Timers.Timer>();
    int interval = 0;      // set this to -300000 if you want the first one to be 0 seconds.
    for (int i = 0; i < people.size(); i++) {
        // Outputs.....
        
        interval += 300000;           // adds up 5 minutes each loop.
        var timer = new System.Timers.Timer()
        timer.Interval = interval;
        timer.Elapsed += (_s, _e) =>{
        using (SqlConnection conn = new SqlConnection(@"Data Source=...")) {
            conn.Open();
    
            using (SqlCommand cmd1 = new SqlCommand("INSERT INTO...", conn)) {
                using (SqlDataReader dr = cmd1.ExecuteReader()) {}
            }
        }
        timers.add(timer);
    }; 
    
    foreach (var t in timers) {
        t.Enabled = true;
    }
