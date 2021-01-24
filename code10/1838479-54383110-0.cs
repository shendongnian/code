       protected async Task<ArrayList> CheckReservations(string day)
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("reservation_day", day));
                var content = new FormUrlEncodedContent(postData);
                var response = await _client.PostAsync(Url, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync(); 
                    List<Reservations> myData = JsonConvert.DeserializeObject<List<Reservations>>(json);
                    foreach(Reservations res in myData)
                    {
                     reservations.Add(res.reservation_time);
                    }
                    return reservations;
                }
                else  { return new ArrayList();  }
            }
            catch (Exception e)
            {
                Debug.WriteLine("" + e);
                return new ArrayList();
            }
        }
        return reservations ;
    }
