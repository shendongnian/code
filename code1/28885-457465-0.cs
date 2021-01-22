		public static ElementDefinitionImpl[] RemoveElementDefAt(
			ElementDefinition[] oldList,
			int removeIndex
		)
		{
			ElementDefinitionImpl[] newElementDefList = new ElementDefinitionImpl[ oldList.Length - 1 ];
			int offset = 0;
			for ( int index = 0; index < oldList.Length; index++ )
			{
				ElementDefinitionImpl elementDef = oldList[ index ] as ElementDefinitionImpl;
				if ( index == removeIndex )
				{
					//	This is the one we want to remove, so we won't copy it.  But 
					//	every subsequent elementDef will by shifted down by one.
					offset = -1;
				}
				else
				{
					newElementDefList[ index + offset ] = elementDef;
				}
			}
			return newElementDefList;
		}
