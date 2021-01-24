    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class viewModel : INotifyPropertyChanged
    {
     public event PropertyChangedEventHandler PropertyChanged;
     private string age_;
     public string Age { get { return age_; } set { if (age_ != value) { age_ = ProcessAge(value); OnPropertyChanged(); } } }
     private string ProcessAge(string age)
     {
        if (string.IsNullOrEmpty(age))
            return age;
        if (age.Length > 3)
            age = age.Substring(0, 3);
        if (age.StartsWith("0"))
            age = age.Remove(0, 1);
        return age.Replace(".", "").Replace("-", "");
     }
     private void OnPropertyChanged([CallerMemberName] string propertyName = null)
     {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
    }
