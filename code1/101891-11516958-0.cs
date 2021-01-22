    string[] servers = new string[] {
            "nist1-ny.ustiming.org",
            "nist1-nj.ustiming.org",
            "nist1-pa.ustiming.org",
            "time-a.nist.gov",
            "time-b.nist.gov",
            "nist1.aol-va.symmetricom.com",
            "nist1.columbiacountyga.gov",
            "nist1-chi.ustiming.org",
            "nist.expertsmi.com",
            "nist.netservicesgroup.com"
            };
    string dateStart, dateEnd;
    void SetDateToday()
        {
            Random rnd = new Random();
            DateTime result = new DateTime();
            int found = 0;
            foreach (string server in servers.OrderBy(s => rnd.NextDouble()).Take(5))
            {
                Console.Write(".");
                try
                {
                    string serverResponse = string.Empty;
                    using (var reader = new StreamReader(new System.Net.Sockets.TcpClient(server, 13).GetStream()))
                    {
                        serverResponse = reader.ReadToEnd();
                        Console.WriteLine(serverResponse);
                    }
                    if (!string.IsNullOrEmpty(serverResponse))
                    {
                        string[] tokens = serverResponse.Split(' ');
                        string[] date = tokens[1].Split(' ');
                        string time = tokens[2];
                        string properTime;
                        dateStart = date[2] + "/" + date[0] + "/" + date[1];
                        int month = Convert.ToInt16(date[0]), day = Convert.ToInt16(date[2]), year = Convert.ToInt16(date[1]);
                        day = day + 30;
                        if ((month % 2) == 0)
                        {
                            //MAX DAYS IS 30
                            if (day > 30)
                            {
                                day = day - 30;
                                month++;
                                if (month > 12)
                                {
                                    month = 1;
                                    year++;
                                }
                            }
                        }
                        else
                        {
                            //MAX DAYS IS 31
                            if (day > 31)
                            {
                                day = day - 31;
                                month++;
                                if (month > 12)
                                {
                                    month = 1;
                                    year++;
                                }
                            }
                        }
                        string sday, smonth;
                        if (day < 10)
                        {
                            sday = "0" + day;
                        }
                        if (month < 10)
                        {
                            smonth = "0" + month;
                        }
                        dateEnd = sday + "/" + smonth + "/" + year.ToString();
                    }
                }
                catch
                {
                    // Ignore exception and try the next server
                }
            }
            if (found == 0)
            {
                MessageBox.Show(this, "Internet Connection is required to complete Registration. Please check your internet connection and try again.", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Success = false;
            }
        }
