            List<string> times1 = new List<string>(new string[] { "00:15", "01:01" });
            List<string> times2 = new List<string>(new string[] { "00:16", "01:00" });
            List<string> result = new List<string>();
            for (int i = 0; i < times1.Count; i++)
                {
                if (int.Parse(times1[i].Substring(0, 2)) > int.Parse(times2[i].Substring(0, 2))) //check hours
                    {
                    result.Add(times1[i]);
                    }
                else
                    {
                    if (int.Parse(times1[i].Substring(0, 2)) < int.Parse(times2[i].Substring(0, 2)))
                        {
                        result.Add(times2[i]);
                        }
                    else  //check minuts
                        {
                        if (int.Parse(times1[i].Substring(3, 2)) > int.Parse(times2[i].Substring(3, 2)))
                            {
                            result.Add(times1[i]);
                            }
                        else
                            {
                            if (int.Parse(times1[i].Substring(3, 2)) <= int.Parse(times2[i].Substring(3, 2)))
                                {
                                result.Add(times2[i]);
                                }
                            }
                        }
                    }
                }
