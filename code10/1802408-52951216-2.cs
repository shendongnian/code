    using ProjectX.Model;
    using System.Collections.ObjectModel;
    namespace ProjectX.ViewModel
    {
      public class ViewModelMain : ViewModelBase
      {
        public ObservableCollection<Waage> WaageListe {get;} = new ObservableCollection<Waage>();
        public ViewModelMain()
        {
           WaageListe.Add(new Waage {Name="Hamburg - 1"});
           WaageListe.Add(new Waage {Name="Hamburg - 2"});
           WaageListe.Add(new Waage {Name="Hamburg - 3"});
        }
      }
    }
