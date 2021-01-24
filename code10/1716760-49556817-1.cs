       protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            strtotalID = DataBinder.Eval(e.Row.DataItem, "city_name").ToString();
                    double TtCounter = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CounterAmt").ToString());
                    TotalCounter += TtCounter;
                 
                    GrandTotalCounter += TCounter;
                 /// Add how much you want 
              }
