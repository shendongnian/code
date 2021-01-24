    public interface ITier2ViewModelFactory
    {
       Tier2ViewModel CreateViewModel(Tier2Entity tier2Entity);
    }
    public class Tier2ViewModelFactory : ITier2ViewModelFactory
    {
       public Tier2ViewModel CreateViewModel(Tier2Entity tier2Entity)
       {
         return new Tier2ViewModel(tier2Entity);
       }
    }
    public class Tier1ViewModel
    {
       private readonly ITier2ViewModelFactory _tier2ViewModelFactory;
       private void LoadTier2()
       {
          //TODO: load tier2Entities using EF
          //TODO: foreach tier2Entity, call _tier2ViewModelFactory.CreateViewModel(tier2Entity)
          //TODO: add each Tier2ViewModel instance to ObservableCollection<Tier2ViewModel>
       }
