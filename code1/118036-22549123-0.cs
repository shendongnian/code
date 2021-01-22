    [ManagesType(typeof(SPEC_SEC_OC), true)]
    [ManagesType(typeof(SPEC_SEC_04_OC), true)]
    public class LibSpecSelectionView : CustomView
    {
        public LibSpecSelectionView(SPEC_SEC_OC)
        {}
        public LibSpecSelectionView(SPEC_SEC_O4_OC)
        {}
        ....
    }
    public static class ViewManager
    {
       ...  static Dictionary of views built via reflection
       public void LaunchView(this CollectionBaseClass cbc)
       {
           ... Find class registered to handle cbc type in dictionary and call ctor
       }
    }
    SPEC_SEC_OC myOC = DataClient.Instance.GetSPEC_SEC_OC();
    myOC.LaunchView()
    
