         public async void SomeMethod()
        {
            using (var httpclient = new HttpClient())
            {
                for (int i = 0; i < 5000; i++)
                {
                    DateTime dt = DateTime.Now;
                    dt = dt.AddSeconds(-dt.Second);
                    Log[] data1 = new Log[]
                    {
                        log =new Log(){LogID=Guid.NewGuid(),LogLevel=new LogLevel(){ },Message="Maverick_Messgaes",Source="Maverick",StackTrace="Maverick Started",
                        Time=dt,Traceid="1"},
                    }
                    await httpclient.PostAsJsonAsync("http://localhost:8095/api/Log/PostAsync", data1);                            
                }
            }            
        }
