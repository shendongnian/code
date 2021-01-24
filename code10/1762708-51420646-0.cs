    //TODO: what is the magic number (date) 24 May 2018?
    private Boolean IsLastPay() {
      if (Parameters.TryGetValue("Last Pay Date", out var dateSt))
        if (DateTime.TryParse(dateSt, out var paramDate))
          return paramDate >= new DateTime(2018, 5, 24);
        else
          return false; // DateTime.TryParse failed to parse the parameter
      else
        return false;   // Parameters.TryGetValue failed to get the value
    }
