    public void EnumsCombo ()
    {
          var _enumval = Enum.GetValues ​​(typeof (Proyect.Model.TYPE_IDENTITY)).Cast<Proyect.Model.TYPE_IDENTITY> ();
          var x = _enumval.ToList();
          CobIdenti.ItemsSource = x;
    }
