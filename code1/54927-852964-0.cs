    public class TheClass : INotifyPropertyChanged
    {
    public IEnumerable<Patient> Patients
      {
        get
        {
                return from patient in Database.Patients
                       orderby patient.Lastname
                       select patient;
        }
      }
    #region INotifyPropertyChanged members
    // Generated code here
    #endregion
    public void PatientsUpdated()
    {
      if (PropertyChanged != null)
        PropertyChanged(this, "Patients");
    }
    }
