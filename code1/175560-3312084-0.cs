        private int? Tid; 
        public int? innerTenantID {  
            get { return Tid; }  
            set {  
                Tid = value;  
                innerTenant = (value.HasValue)? Tenant.GetTenantByID(value.Value) : null; 
            }  
        } 
