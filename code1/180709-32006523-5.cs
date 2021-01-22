    // using System.ComponentModel;
    partial class DataSource : INotifyPropertyChanged
    {
        [TypeConverter(typeof(BooleanToColorConverter))] // <-- add this! 
        public bool IsValid { get { … } set { … } }
    }
