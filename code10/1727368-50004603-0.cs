    public void SomeDataMethod()
    {
        using (var conn = new SqlConnection(ConnString))
        {
            conn.Open();
            var data = new Dictionary<string, List<object>>();
            foreach (var h in hours)
            {
                data += SqlUniversal.GetAllData(query,
                    new[] {
                        //some parameters
                    },
                    conn);
            }
        }
    }
