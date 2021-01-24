    <ContentTemplate>
                <asp:GridView ID="GridView1" CssClass="table table-condensed" runat="server" OnRowCommand="GridView1_RowCommand" DataKeyNames="bookingid" AutoGenerateColumns="false">
    
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
    
                        <asp:ButtonField CommandName="download"
                            ControlStyle-CssClass="btn btn-info" ButtonType="Button"
                            Text="Download Invoice" HeaderText="Invoice" />
                        <asp:BoundField DataField="bookingid" HeaderText="Booking ID" />
                        <asp:BoundField DataField="hotelName" HeaderText="Hotel Name" />
                        <asp:BoundField DataField="Booking_Status" HeaderText="Booking Status" />
                        <asp:BoundField DataField="Check_In" HeaderText="Check In" />
                        <asp:BoundField DataField="Check_Out" HeaderText="Check Out" />
                        <asp:BoundField DataField="RoomTypeName" HeaderText="Room Type" />
                        <asp:BoundField DataField="NoOfRoomsBooked" HeaderText="No of Rooms Booked" />
                            
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                         <asp:BoundField HeaderText="Image" DataField="NationalID" Visible="false" />
                        <asp:TemplateField HeaderText="NationalID" >
                            <ItemTemplate>
                                <asp:Image ID="Image1"  runat="server" ImageUrl='<%# "imageHandler.ashx?bookingId="+ Eval("bookingId") %>'  
                                Height="150px" Width="150px" />  
                             <%--   <asp:Image ID="Image1" CssClass="default"  runat="server" 
                                    ImageUrl='<%# "data:Image/jpg;base64,"
                    	+ Convert.ToBase64String((byte[])Eval("NationalID")) %>' />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
    
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="hiddenprimary" />
                <div style="margin-left: 1500px;">
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </div>
    
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    
    namespace HotelReservation.Views
    {
        /// <summary>
        /// Summary description for ImageHandler
        /// </summary>
        public class ImageHandler : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                string imageid = context.Request.QueryString["bookingId"];
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyProjectConnection"].ConnectionString))
                {
    
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("select NationalID from tblReservation where bookingid=" + imageid, connection);
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();
                    context.Response.BinaryWrite((Byte[])dr[0]);
                    connection.Close();
                    context.Response.End();
                  
                }
            
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
