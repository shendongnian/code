    [WebService(Namespace = "http://mynamespace.com/ModifierCodesService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class ModifierCodesService : System.Web.Services.WebService
    {
      
         /// <summary>
        /// Get a list of Modifiers
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public Modifier[] GetModifierList()
        {
            return GetModifiers();
        }
           /// <summary>
            /// Modifiers list from database
            /// </summary>
            /// <returns></returns>
            private Modifier[] GetModifiers()
            {
                List<Modifier> modifier = new List<Modifier>();
                ModifierCollection matchingModifiers = ModifierList.GetModifierList();
                foreach (Modifier ModifierRow in matchingModifiers)
                {
                    modifier.Add(new Modifier(ModifierRow.ModifierCode, ModifierRow.Description));
                }
                return modifier.ToArray();
            }
        }
