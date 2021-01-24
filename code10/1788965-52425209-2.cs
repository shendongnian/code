    public partial class SIMSSupplier : UserControl
    {
        private ADDSupplier supply;
        public DataTable dbdataset;
        public DataSet ds = new DataSet();
        public string ID = "SPPLR-000";
        public int id;
        DataView db;
        public SIMSSupplier()
        {
            InitializeComponent();
        }
        public void SupplierDetails()
        {
            DoRequestAndFill(Supplierview, "Select SupplierID, Companyname, Contactname, Contactnumber as 'Contact Number', Date, Address, Remarks from Supplier_Details");
        }
        public void DeliveryDetails()
        {
            DoRequestAndFill(PurchaseDeliveries, "Select PurchaseID, Supplier, Itemdescription, Date, Quantity, Unitcost, Amount, Salesinvoice, Codeitems, Patientname from Purchase_Delivery");
        }
        public void OrderDetails()
        {
            DoRequestAndFill(PurchaseOrders, "Select PurchaseID, Supplier, Itemdescription, Date, Quantity, Unitcost, Amount, Salesinvoice, Codeitems, Patientname from Purchase_Order");
        }
        private void DoRequestAndFill(DataGridView grid, string request) 
        {
            using (var con = SQLConnection.GetConnection())
            using (var select = new SqlCommand(request, con))
            using (var sda = new SqlDataAdapter())
            {
                dbdataset = new DataTable();
                sda.SelectCommand = select;
                sda.Fill(dbdataset);
                grid.DataSource = new BindingSource() { DataSource = dbdataset };
                sda.Update(dbdataset); 
            }
        }
    }
 
