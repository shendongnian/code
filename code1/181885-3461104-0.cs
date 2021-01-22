    public ObservableCollection<TypeA> ItemsOfTypeA { get; set; }
    private ObservableCollection<TypeB> _ItemsOfTypeB;
    public ObservableCollection<TypeB> ItemsOfTypeB
    {
       get
       {
          if (_ItemsOfTypeB == null)
          {
             var converted = ItemsOfTypeA.Select(ConvertTypeAToTypeB);
             _ItemsOfTypeB = new ObservableCollection<TypeB>(converted);
          }
          return _ItemsOfTypeB;
       }
    }
    private TypeB ConvertTypeAToTypeB(TypeA a)...
