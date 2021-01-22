    <asp:TemplateField HeaderText="# Percentage click throughs">
      <ItemTemplate>
        <%# AddPercentClickThroughs(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "EmailSummary.pLinksClicked")), Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "NumberOfSends")))%>
      </ItemTemplate>
    </asp:TemplateField>
    public string AddPercentClickThroughs(decimal NumberOfSends, decimal EmailSummary.pLinksClicked)
    {
        decimal OccupancyPercentage = 0;
        if (TotalNoOfRooms != 0 && RoomsOccupied != 0)
        {
            OccupancyPercentage = (Convert.ToDecimal(NumberOfSends) / Convert.ToDecimal(EmailSummary.pLinksClicked) * 100);
        }
        return OccupancyPercentage.ToString("F");
    }
