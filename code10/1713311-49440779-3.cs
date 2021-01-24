    namespace WebApplication3
    {
    	public partial class _Default : Page
    	{
    		protected void Page_Load( object sender, EventArgs e )
    		{
    			if ( !Page.IsPostBack )
    			{
    				List<Parts> ListOfParts = new List<Parts>( new Parts[ ] {
    							new Parts(0, 0),
    							new Parts(0, 0),			
    							new Parts(0, 0) } );
    
    				gvPartsToOrderDetail.DataSource = ListOfParts;
    				gvPartsToOrderDetail.DataBind();
    			}
    		}
    
    		protected void Button1_PreRender( object sender, EventArgs e )
    		{
    			Button1.OnClientClick = string.Format( "return Page_ClientValidate('vgSubmit_{0}')", gvPartsToOrderDetail.SelectedIndex );
    		}
    	}
    
    	//------------------------------------------------------------
    	// Dummy data class
    	//
    	public class Parts {
    		public Parts( int ticketNo, int status ) {
    			TicketNo = ticketNo;
    			Status = status;
    		}
    
    		public int TicketNo { get; set; }
    		public int Status { get; set; }
    	}
    }
