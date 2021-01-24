    public abstract class ControlledMainClassDataInColumns
    {
        public static Dictionary<string, List<TableFieldReference>> tableFieldReferences = new Dictionary<string, List<TableFieldReference>>();
    }
    public class Employee : ControlledMainClassDataInColumns
    {
        static Employee()
        {
            var list = new List<TableFieldReference>();
            // populate list
            tableFieldReferences["Employee"] = list;
        }
    }
