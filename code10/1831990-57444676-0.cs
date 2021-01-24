        [Fact]
		public void AllMappedPropertiesAreSameTypeOrAreMappedExplicitly()
		{
			ServiceCollection theCollection = new ServiceCollection();
			theCollection.AddMssAutoMapper();
			IMapper theMapper = BuildProductionMapper();
            //Store all explicit mappings for easy lookup
			System.Collections.Generic.HashSet<(Type SourceType, Type DestType)> theExplicitMappings =
				theMapper.ConfigurationProvider.GetAllTypeMaps()
				.Select( map => (map.SourceType, map.DestinationType) )
				.ToHashSet();
			var theIllegalMaps =
			from typeMap in theMapper.ConfigurationProvider.GetAllTypeMaps()
			from propMap in typeMap.PropertyMaps
			let sourceType = propMap.SourceType
			let destType = propMap.DestinationType
			let bothTypes = new[] { sourceType, destType }
			where sourceType != null && destType != null
			where sourceType != destType
			//Anything that's explicitly mapped is permitted
			where !theExplicitMappings.Contains( (sourceType, destType) )
			//enums to string and vice versa is permitted
			where !( sourceType.IsEnum || sourceType == typeof( string ) && destType.IsEnum || destType == typeof( string ) )
			//mapping from one collection to another is okay
			where !bothTypes.All( type => type.IsAssignableTo( typeof( IEnumerable ) ) )
			select new
			{
				SourceType = typeMap.SourceType,
				DestinationType = typeMap.DestinationType,
				SourceMemberName = propMap.SourceMember.Name,
				DestMemberName = propMap.DestinationMember.Name,
				SourceMemberType = sourceType,
				DestinationMemberType = destType
			};
			var illegalMapsList = theIllegalMaps.ToList();
			foreach( var illegalMap in illegalMapsList )
			{
				Console.Out.WriteLine( $"Found disallowed property mapping from '{illegalMap.SourceType}.{illegalMap.SourceMemberName}' to '{illegalMap.DestinationType}.{illegalMap.DestMemberName}'" );
				Console.Out.WriteLine( $"Property name: {illegalMap.SourceMemberName}" );
				Console.Out.WriteLine( $"implicit mapping from {illegalMap.SourceMemberType} to {illegalMap.DestinationMemberType} is not allowed." );
				Console.Out.WriteLine( $"Please map these types explicitly." );
			}
			if( illegalMapsList.Any() )
			{
				throw new Exception( "One or more ambiguous mappings were found that need to be handled explicitly.  See console output for details." );
			}
		}
