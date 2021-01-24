    public static string GetRadioButtonValue(ControlCollection ctrlColl, string groupName)
    {
      var selectedRbtn= controls.OfType<RadioButton>().FirstOrDefault(rb => rb.GroupName == groupName && rb.Checked);
      return selectedRbtn== null ? string.Empty :selectedRbtn.Attributes["Value"];
}
