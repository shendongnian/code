    public class NodeHeaders
    {
        public static string node_name = "Conduit Name";
        public static string x = "Easting (m)";
        public static string y = "Northing (m)";
        public static string z_cover = "Cover Level (m)";
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataGridViewNodes_CellValueChanged();
            
        }
    private static void DataGridViewNodes_CellValueChanged()
    {
            try
            {
          
        foreach (FieldInfo prop in typeof(NodeHeaders).GetFields())
        {
            
            object item = prop.GetValue(null);
                    Console.WriteLine($"{prop.Name} = {item.ToString()}");
        }
            }
            catch (Exception ex)
            {
                throw;
            }
            Console.ReadKey();
    }
}
