        public class CreateRMAVM
        {
        public List<vare> vares { get; set; }
        public string CustomerName { get; set; }
    
        public class vare
        {
        public vare()
        {
        }
        public vare(/*string CustomerName*/ string ProductName, string SerialNumber, string Qty)
        {
        }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public string Qty { get; set; }
        }
         }
