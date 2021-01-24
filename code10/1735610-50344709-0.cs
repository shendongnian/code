    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using yourNameSpace;
    //
    //    var orderResponse = OrderResponse.FromJson(jsonString);
    namespace yourNameSpace
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    public partial class OrderResponse
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }
        [JsonProperty("employeeId")]
        public string EmployeeId { get; set; }
        [JsonProperty("orderTime")]
        public long OrderTime { get; set; }
        [JsonProperty("orderCost")]
        public long OrderCost { get; set; }
        [JsonProperty("comments")]
        public object Comments { get; set; }
        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }
        [JsonProperty("orderedItems")]
        public List<OrderedItem> OrderedItems { get; set; }
    }
    public partial class OrderStatus
    {
        [JsonProperty("orderStatusId")]
        public long OrderStatusId { get; set; }
        [JsonProperty("orderStatusName")]
        public string OrderStatusName { get; set; }
    }
    public partial class OrderedItem
    {
        [JsonProperty("orderItemId")]
        public long OrderItemId { get; set; }
        [JsonProperty("orderQuantity")]
        public long OrderQuantity { get; set; }
        [JsonProperty("orderItemCost")]
        public long OrderItemCost { get; set; }
    }
    public partial class OrderResponse
    {
        public static List<OrderResponse> FromJson(string json) => JsonConvert.DeserializeObject<List<OrderResponse>>(json);
    }
