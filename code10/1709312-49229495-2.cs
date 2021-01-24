    class SampleEntity : INotifyPropertyChanged
    {
        DateTime date = DateTime.Now, then = DateTime.Now;
        #region Constructor
        public SampleEntity()
        {            
        }
        #endregion
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public List<StudentEntity> StudentsList { get; set; }
        public StudentEntity SelectedStudent { get; set; }
        #endregion
        #region Notify Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
    class StudentEntity : INotifyPropertyChanged
    {
        DateTime date = DateTime.Now, then = DateTime.Now;
        #region Constructor
        public StudentEntity()
        {
        }
        #endregion
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region Notify Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
