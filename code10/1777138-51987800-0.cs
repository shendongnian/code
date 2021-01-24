        protected CustomFields( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
            if( info == null )
                throw new ArgumentNullException( "info" );
            this.CustomFieldDictionary = ( IDictionary<string, string> ) info.GetValue( "CustomFieldDictionary", typeof( IDictionary<string, string> ) );
        }
        [SecurityPermission( SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter )]
        public override void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            if( info == null )
                throw new ArgumentNullException( "info" );
            base.GetObjectData( info, context );
            
            // Following line throws
            info.AddValue( "CustomFieldDictionary", this.CustomFieldDictionary, typeof( IDictionary<string, string> ) );
        }
