    using Magento_Import.MagentoAPI;
    
    namespace Magento_Import
    {
        public partial class _Default : System.Web.UI.Page
        {
            Mage_Api_Model_Server_V2_HandlerPortTypeClient handler = new Mage_Api_Model_Server_V2_HandlerPortTypeClient();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                string session = handler.login("username", "password");
                
                catalogProductEntity[] products;
                handler.catalogProductList(out products, session, null, null);
            }
        }
    }
