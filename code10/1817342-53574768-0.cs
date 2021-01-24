    public async Task<IEnumerable<StatItemListViewModel>> GetTable(string sDate, string eDate)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                var results = await connection.QueryAsync<StatItemListViewModel>("Call MainResult_Statistic(@sDate, @eDate)", 
                    new { sDate, eDate });
                return results.ToList();
           }                  
        }
