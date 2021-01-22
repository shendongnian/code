        public class Utility {
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] GetCompletionList(string prefixText, int count) {
            return new string[] { "Bruno", "Simon", "Joanie", "Noémie", "Johanne", "Serge", "France", "Jacques", "Mylène" };
        }
    }
