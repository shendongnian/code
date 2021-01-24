    str = "select * from Schedule where [Commencing] = [Finishing]";
    com = new SqlCommand(str, con);
    ArrayList Scheduling = ConnectionClass.GetCloseSchedule(lblMsgO.Text);
    foreach (Scheduling schedules in Scheduling)
    {
        sb.Append(string.Format(@"{0}<br />",
           schedules.Working));
    }
    lblMsgO.Text = sb.ToString();
    sb.Clear();
    reader.Close();
    con.Close();
