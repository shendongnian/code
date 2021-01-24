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
            DoRequestAndFill("Select SupplierID, Companyname, Contactname, Contactnumber as 'Contact Number', Date, Address, Remarks from Supplier_Details");
        }
        public void DeliveryDetails()
        {
            DoRequestAndFill("Select PurchaseID, Supplier, Itemdescription, Date, Quantity, Unitcost, Amount, Salesinvoice, Codeitems, Patientname from Purchase_Delivery");
        }
        public void OrderDetails()
        {
            DoRequestAndFill("Select PurchaseID, Supplier, Itemdescription, Date, Quantity, Unitcost, Amount, Salesinvoice, Codeitems, Patientname from Purchase_Order");
        }
        private void DoRequestAndFill(string request) 
        {
            using (var con = SQLConnection.GetConnection())
            {
                using (var select = new SqlCommand(request, con))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = select;
                        dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        var bsource = new BindingSource();
                        bsource.DataSource = dbdataset;
                        PurchaseDeliveries.DataSource = bsource;
                        sda.Update(dbdataset);
                    }
                }
            }
        }
    }
 
