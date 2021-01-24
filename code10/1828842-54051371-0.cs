	[global::System.Diagnostics.DebuggerNonUserCodeAttribute]
	public void MergeFrom( pb::CodedInputStream input )
	{
		uint tag;
		while ( ( tag = input.ReadTag() ) != 0 )
		{
			switch ( tag )
			{
				default:
					_unknownFields = pb::UnknownFieldSet.MergeFieldFrom( _unknownFields, input );
					break;
				case 10:
					{
						Id = input.ReadString();
						break;
					}
				case 18:
					{
						Name = input.ReadString();
						break;
					}
			}
		}
	}
