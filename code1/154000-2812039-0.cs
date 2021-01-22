             private void timer1_Tick(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select Lesson_Time from schedule where Lesson_Time >= (?LessonTime) AND Room_NO=(?RoomNO)And Day_Name = (?DayName) order by Lesson_Time ASC limit 0, 1 ", connection);
            MySqlParameter param1 = new MySqlParameter();
            MySqlParameter param2 = new MySqlParameter();
            MySqlParameter param3 = new MySqlParameter();
            param1.ParameterName = "?LessonTime";
            param1.Value = DateTime.Now.AddMilliseconds(60000).ToShortTimeString();
            param2.ParameterName = "?RoomNO";
            param2.Value = serverListBox.SelectedItem.ToString();
            param3.ParameterName = "?DayName";
            param3.Value = DateTime.Today.Day;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nextLessonTime = DateTime.Parse(reader["Lesson_Time"].ToString());
                    //  timer1.Interval = ().;
                    Console.WriteLine(("Between Time ") + (nextLessonTime - DateTime.Now));
                }
            }
            else
            {
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand("select Day_Name , Lesson_Time  from schedule where  Room_NO=(?RoomNO)AND Week_NO=(?WeekNO)AND Day_Name=(?DayName) ", connection);
                MySqlParameter param4 = new MySqlParameter();
                MySqlParameter param5 = new MySqlParameter();
                MySqlParameter param6 = new MySqlParameter();
                param4.ParameterName = "?RoomNO";
                param4.Value = serverListBox.SelectedItem.ToString();
                param5.ParameterName = "?DayName";
                param5.Value = DateTime.Today;
                param6.ParameterName = "?WeekNO";
                if (DateTime.Now.DayOfYear / 7 % 2 == 1)
                    param6.Value = (1);
                else
                    param6.Value = (2);
                cmd2.Parameters.Add(param4);
                cmd2.Parameters.Add(param5);
                cmd2.Parameters.Add(param6);
                cmd2.ExecuteNonQuery();
                reader2 = cmd2.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                      
                        if (reader2["Day_Name"].ToString() == "Monday" && ((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                        else if (reader2["Day_Name"].ToString() == "Tuesday" && ((int)DayOfWeek.Tuesday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Tuesday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                        else if (reader2["Day_Name"].ToString() == "Wednesday" && ((int)DayOfWeek.Wednesday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Wednesday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                        else if (reader2["Day_Name"].ToString() == "Thursday" && ((int)DayOfWeek.Thursday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Thursday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                        else if (reader2["Day_Name"].ToString() == "Friday" && ((int)DayOfWeek.Friday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Friday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                            
                        else if (reader2["Day_Name"].ToString() == "Saturday" && ((int)DayOfWeek.Saturday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Saturday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                        else if (reader2["Day_Name"].ToString() == "Sunday" && ((int)DayOfWeek.Sunday - (int)DateTime.Today.DayOfWeek) > 0)
                        {
                            nextLessonTime = DateTime.Parse(reader2["Lesson_Time"].ToString()).AddDays((int)DayOfWeek.Sunday - (int)DateTime.Today.DayOfWeek);
                            break;
                        }
                       
                    }
                }
                else
                {
                    reader2.Close();
                    MySqlCommand cmd3 = new MySqlCommand("select Day_Name , Lesson_Time  from schedule where  Room_NO=(?RoomNO)AND Week_NO=(?WeekNO) limit 0,1 ", connection);
                    MySqlParameter param7 = new MySqlParameter();
                    MySqlParameter param8 = new MySqlParameter();
                    MySqlParameter param9 = new MySqlParameter();
                    param7.ParameterName = "?RoomNO";
                    param7.Value = serverListBox.SelectedItem.ToString();
                    param8.ParameterName = "?DayName";
                    param8.Value = DateTime.Today.Day;
                    param9.ParameterName = "?WeekNO";
                    if (DateTime.Now.DayOfYear / 7 % 2 == 1)
                        param9.Value = (2);
                    else
                        param9.Value = (1);
                    cmd3.Parameters.Add(param7);
                    cmd3.Parameters.Add(param8);
                    cmd3.Parameters.Add(param9);
                    cmd3.ExecuteNonQuery();
                    reader3 = cmd3.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        while (reader3.Read())
                        {
                            nextLessonTime = DateTime.Parse(reader3["Lesson_Time"].ToString()).Next((DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader3["Day_Name"].ToString()));
                        }
                    }
                    reader3.Close();
                }
                connection.Close();
                nextInterval = (nextLessonTime - DateTime.Now).TotalMilliseconds.ToString();
                Console.WriteLine("Next INTERVAL  " + nextInterval);
                timer1.Interval = (int)(nextLessonTime - DateTime.Now).TotalMilliseconds;
                Console.WriteLine("Timer INTERVAL " + timer1.Interval);
                this.logListView.Items.Add("Server " + serverListBox.SelectedItem.ToString() + " Searched at " + DateTime.Now + " Next Search at " + nextLessonTime);
            }
 
