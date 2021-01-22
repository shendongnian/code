        public static string DDl_order(int orderId)
            {
                string format = "<option value=\"{0}\" {2} >{1}</option>";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat(format, "", "--Select--", "");
                List<Models.UrClass> urclass=orderRepository.GetCustomers();
    
                foreach (var item in client)
                {
                    string ordid = item.orderId.ToString().Encrypt();
    
                    if (item.ClientID == orderId)
                        sb.AppendFormat(format, orderid , item.OrdName,selected=\"selected\"");
                    else
                        sb.AppendFormat(format, ordid , item.OrdName, "");
                }
                return sb.ToString();
            }
