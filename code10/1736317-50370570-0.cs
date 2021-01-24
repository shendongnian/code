    private void TryParseDouble(string ParseTarget, string PointField, string FieldInMsg)
    {
     bool resBool; 
      switch (PointField)
      {
          case "SPos":
              resBool = double.TryParse(ParseTarget, out double SPos);
              break;
          case "TPos":
              resBool = double.TryParse(ParseTarget, out double TPos);
              break;
          case "Increment":
              resBool = double.TryParse(ParseTarget, out double Increment);
              break;
          default:              
              break;
      }
        
        if (!resBool) FalseBoolMsg(FieldInMsg);
    }
