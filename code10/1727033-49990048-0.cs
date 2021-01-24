    foreach ( Control ctrl in tabPage4.Controls )
    {
      if ( ctrl.GetType().Equals(typeof(Label)) )
      {
        string strName = ctrl.Name;
        if ( strName.StartsWith("label", StringComparison.InvariantCultureIgnoreCase) )
        {
          string strNum = strName.Substring(5);
          int iIndex;
          if ( int.TryParse(strNum, out iIndex) )
          {
            ctrl.Text = "your text";
          }
        }
      }
    }
