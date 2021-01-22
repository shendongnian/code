    public class ViewModel : ViewModelBase
    {
      private Department department;
      public ViewModel()
      {
        Department = new EnumFlags<Department>(department);
      }
      public Department Department { get; private set; }
    }
