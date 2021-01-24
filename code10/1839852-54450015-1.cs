    if (string.IsNullOrEmpty(myDate.Text) == false)
            {
                myCommand.Parameters.Add("@date", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(myDate.Text);
            }
            else
            {
                myCommand.Parameters.Add("@date", SqlDbType.SmallDateTime).Value =  DateTime.Today();
            }
