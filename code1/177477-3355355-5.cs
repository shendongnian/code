	protected void btnSearch_Click(object sender, EventArgs e)
	{    
	   this.LinqDataSource1.WhereParameters["Subject"].DefaultValue = this.txtSubject.Text;
	   this.GridView1.DataBind();
	}
	public void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
	{ 
		ReporterRepository reporterRepo = new ReporterRepository();
		e.Result = reporterRepo.GetInquiries();    
	}
	public IQueryable<Reporter> GetInquiries()
	{
		return from spName in dc.spReporter()
			   select new Reporter(spName.Id, spName.InqDate, spName.Subject);
	}     
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" EmptyDataText="There are no data records to display."> 
			<Columns> 
				<asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True"  
					SortExpression="UserID" /> 
				<asp:BoundField DataField="Username" HeaderText="Username"  
					SortExpression="Username" /> 
				<asp:BoundField DataField="FirstName" HeaderText="FirstName"  
					SortExpression="FirstName" /> 
				<asp:BoundField DataField="LastName" HeaderText="LastName"  
					SortExpression="LastName" /> 
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" /> 
			</Columns> 
	</asp:GridView> 
	<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="MyDataContextDataContext" onselecting="LinqDataSource_Selecting"> 
			<WhereParameters> 
			   <asp:Parameter Name="Subject" />
			</WhereParameters> 
	</asp:LinqDataSource>
