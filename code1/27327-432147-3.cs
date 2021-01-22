    using System;
    
    namespace Your.Domain
    {
       
        public partial class Address
        {
        
           
            
            #region Attributes and Associations
            
            private string _address1;
            private string _address2;
            private string _city;
            private long _id;
            private string _state;
            private string _zipcode;
    
    		#endregion
    
            #region Properties
            
            /// <summary>
            /// 
            /// </summary>
            public virtual string Address1
            {
                get { return _address1; }
                set { this._address1 = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            public virtual string Address2
            {
                get { return _address2; }
                set { this._address2 = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            public virtual string City
            {
                get { return _city; }
                set { this._city = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            public virtual long Id
            {
                get { return _id; }
                set { this._id = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            public virtual string State
            {
                get { return _state; }
                set { this._state = value; }
            }
    
            /// <summary>
            /// 
            /// </summary>
            public virtual string Zipcode
            {
                get { return _zipcode; }
                set { this._zipcode = value; }
            }
    
    
    		#endregion 
    	}
    }
