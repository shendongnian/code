    public class YourClass
    {
        private Dictionary<string, Action> m_options;
        public YourClass()
        {
         m_options = new Dictionary<string, Action>
         {
          { "ALPHA",  () => LoadGroup(ManagerContext.Current.Group1, "alphaGroup", uxAlphaGrid) },
          { "BRAVO",  () => LoadGroup(ManagerContext.Current.Group2, "bravoGroup", uxBravoGrid) },
          { "CHARLIE",() => LoadGroup(ManagerContext.Current.Group3, "charlieGroup", uxCharlieGrid) },
          { "DELTA",  () => LoadGroup(ManagerContext.Current.Group4, "deltaGroup", uxDeltaGrid) },
         };
        }
        private void LoadGroup(string option)
        {
         Action optionAction;
         if(m_options.TryGetValue(option, out optionAction))
         {
                optionAction();
         }
        }
        private void LoadGroup(TGroup group, string groupName, TGrid grid)
        {
            VList<T> returnList = FetchInformation(group);
            if (Session[groupName] != null)
            {
                    List<T> tempList = (List<T>)Session[groupName];
                    returnList.AddRange(tempList);
            }
            grid.DataSource = returnList;
            grid.DataBind();
        }
    }
