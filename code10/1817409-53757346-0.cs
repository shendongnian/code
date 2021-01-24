         [System.Web.Http.HttpPost]
        public ActionResult PlaceOrder(ClientDetailsModel ClientDetails, List<ProductDetailsModel> ProductDetails, ShippingAddressModel ShippingAddress, string PaymentMode, string CurrencyAbbreviation,string OrderPageURL)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var systemToken = Session["SysToken"].ToString();
            var url = Session["DomainURL"]+"/OrderingManagement/Orders.asmx/PlaceOrder";
            var parameters = "ResponseType=JSON";
            parameters += "&Token=" + systemToken;
            parameters += "&PaymentMode=" + PaymentMode;
            parameters += "&ProductDetails=" + JsonConvert.SerializeObject(ProductDetails);
            parameters += "&ShippingAddress=" + JsonConvert.SerializeObject(ShippingAddress);
            parameters += "&ClientDetails=" + JsonConvert.SerializeObject(ClientDetails);
            parameters += "&CurrencyAbbreviation=" + CurrencyAbbreviation;
            parameters += "&OrderPageURL="+ websiteDomain+"/en/order-details/?comingfrom=email";
            var response = Functions.PostRequest(url, parameters);
            var res = JsonConvert.DeserializeObject(response);
            Session["OrderNo"] = res.No;
            Session["AuthenticationCode"] = res.AuthenticationCode;
            return Json(response);
        }
