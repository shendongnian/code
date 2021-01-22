        conn.Open();
        string conString = "SET DATEFORMAT DMY INSERT INTO AmortPlanT 
    (InvestmentID,StartDate,Maturity,IRate,CoupPerYear,parValue) Values 
    (@IIndex,@StartDate,@Maturity,@IRate,@CouponPerYear,@parValue)";                
    using (SqlCommand myCommand = new SqlCommand(conString, conn))
       {                    
        myCommand.CommandType = CommandType.Text;                    
        myCommand.Parameters.Add("@IIndex", SqlDbType.Int).Value = investmentIndex;                    
        myCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;                    
        myCommand.Parameters.Add("@Maturity", SqlDbType.DateTime).Value = maturity;                    
        myCommand.Parameters.Add("@IRate", SqlDbType.Float).Value = iRate;                    myCommand.Parameters.Add("@CouponPerYear", SqlDbType.Int).Value = coupPerYear;                    
    myCommand.Parameters.Add("@parValue", SqlDbType.Float).Value = parValue;                    myCommand.ExecuteNonQuery();                
    }
