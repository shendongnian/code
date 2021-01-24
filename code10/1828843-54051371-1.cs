    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
	public void MergeFrom( pb::CodedInputStream input )
	{
		uint tag;
		while ( ( tag = input.ReadTag() ) != 0 )
		{
			switch ( tag )
			{
				default:
					Instance.UnknownFields = pb::UnknownFieldSet.MergeFieldFrom( Instance.UnknownFields, input );
					break;
				case 10:
					{
						Instance.Id = input.ReadString();
						break;
					}
				case 18:
					{
						Instance.Name = input.ReadString();
						break;
					}
			}
		}
	}
