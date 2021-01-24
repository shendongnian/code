    @using NameSpace.Models
        @model RMAHistory
        
        <div class="content">
         <form id="RMAForm">
        
           <input type="text" id="Kundenavn" value="@Model.InvoiceDetailsSingelLine.Kundenavn">
           <br/>
           <input id="Ordrenummer" type="text" value="@Model.InvoiceDetailsSingelLine.Ordrenummer">
           <br/>
        
         if (Model != null)
        {
            if (Model.SingelRMAAntals != null)
            {
                if (Model.SingelRMAAntals.TotalRMA == null)
                
                {
                
                    <div style="display:none;" class="col-md-3">
                
                    <input name="Antal_RMA" id="Antal_RMA" value="@Model.SingelRMAAntals.TotalRMA">
                
                    </div>
                
                }
                
                    else
                {
                        <div class="col-md-3">
                
                    <input name="Antal_RMA" id="Antal_RMA" value="@Model.SingelRMAAntals.TotalRMA">
                
                    </div>
                }
                
                }
         }
        </form>
        </div>
