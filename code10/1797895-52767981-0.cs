    public class BarcoClasseViewModel
    public BarcoClasseViewModel()
    {
      Barco = new BarcoViewModel();
      ClasseBarco = new ClasseBarcoViewModel();
      TipoOperacaoDoBarco = new TipoOperacaoDoBarcoViewModel();
    }
    {
      public BarcoViewModel Barco { get; set; }
      public ClasseBarcoViewModel ClasseBarco { get; set; }
      public TipoOperacaoDoBarcoViewModel TipoOperacaoDoBarco{ get; set; }
    }
