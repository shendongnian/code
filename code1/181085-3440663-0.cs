    //ckBoxes is our List<CheckBox>
    for(int i = 0; i < ckBoxes.Count; i++)
    {
      StringBuilder listBuilder = new StringBuilder;
      if(i == ckBoxes.Count -1)
      {
        listBuilder.Append("and " + dayOfWeek)
      }
      else listBuilder.Append(dayOfWeek + ", ");
    }
