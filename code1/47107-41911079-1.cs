    	//
	///<summary>Base class for read-only objects</summary>
	public partial interface IBaseRO  {
		void Initialize( IDTO dto );
		void Initialize( object value );
	}
