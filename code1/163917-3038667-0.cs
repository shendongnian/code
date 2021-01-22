    <div id="CustomerDetails"> 
        <% Html.RenderPartial("CustomerDetails", new {OrderID = Model.OrderID,  CustomerDetails = Model.CustomerDetails}); %> 
    </div> 
     
    <div id="DeliveryDetails"> 
        <% Html.RenderPartial("DeliveryDetails", new {OrderID = Model.OrderID, DeliveryDetails = Model.DeliveryDetails); %> 
    </div> 
