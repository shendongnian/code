    public class Person : INotifyPropertyChanged
    {
       private bool _employed;
       public bool Employed
       {
          get { return _employed; }
          set
          {
             _employed = value;
             OnPropertyChanged(c => c.Employed);
          }
       }
        
       // etc
        
       private void OnPropertyChanged(Expression<Func<Person, object>> property)
       {
          if (PropertyChanged != null)
          {
             PropertyChanged(this, 
                 new PropertyChangedEventArgs(BindingHelper.Name(property)));
          }
       }
        
       public event PropertyChangedEventHandler PropertyChanged;
    }
