    public interface IPanelFragment
    {
            Fragment Fragment { get; set; }
            // ?? - access modifer for set
            int Position { get; }
    }
    class PanelFragment : IPanelFragment
    {
          public Fragment Fragment { get; set; }
          // ?? - access modifer for set
          public int Position { get; set; }
    }
    private IPanelFragment[] _panels;
    public IPanelFragment CreateFragment(Fragment fragment, int pos)
    {
         return new PanelFragment() { Fragment= fragment, Position = pos };
    }
    public IPanelFragment this[int i]
    {
          get
          {
              return _panels[i];
          }
          set
          {
               _panels[i] = value;
               // !! - cannot access private property
               ((PanelFragment)_panels[i]).Position = i;
           }
      } 
