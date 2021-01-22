		public function getSelectors( targetCSS:String, includeElements:Boolean = true ):ArrayCollection
		{
			
			var newSelectorCollection:ArrayCollection = new ArrayCollection();
			
			if( targetCSS == null || targetCSS == "" ) return newSelectorCollection;
			
			var newSelectors:Array = new Array();
			
			var elements:Array = new Array();
			var ids:Array = new Array();
			var classes:Array = new Array();
			
			// Remove comments
			var cssString:String = "";
			var commentParts:Array = targetCSS.split( "/*" );
			
			for( var c:int = 0; c < commentParts.length; c++ ){
				
				var comPart:String = commentParts[ c ] as String;
				
				var comTestArray:Array = comPart.split( "*/" );
				
				if( comTestArray.length > 1 ){
					
					comTestArray.shift();
					comPart = comTestArray.join( "" );
					
				}
				
				cssString += comPart;
				
			}
			
			// Remove \n
			cssString = cssString.split( "\n" ).join( "" );
			// Remove \t
			cssString = cssString.split( "\t" ).join( "" );
			// Split at }
			var cssParts:Array = cssString.split( "}" );
			
			for( var i:int = 0; i < cssParts.length; i++ ){
				
				var cssPrt:String = cssParts[ i ] as String;
				
				// Detect nesting such as media queries by finding more than one {
				var nestingTestArray:Array = cssPrt.split( "{" );
				
				// If there is nesting split at { then drop index 0 and re-join with {
				if( nestingTestArray.length > 2 ){
					
					nestingTestArray.shift();
					cssPrt = nestingTestArray.join( "{" );
					
				}
				
				// Split at each item at {
				var cssPrtArray:Array = cssPrt.split( "{" );
				
				// Disregard anything after {
				cssPrt = cssPrtArray[ 0 ] as String;
				
				// Split at ,
				var selectorList:Array = cssPrt.split( "," );
				
				for( var j:int = 0; j < selectorList.length; j++ ){
					
					var sel:String = selectorList[ j ] as String;
					
					// Split at : and only keep index 0
					var pseudoParts:Array = sel.split( ":" );
					
					sel = pseudoParts[ 0 ] as String;
					
					// Split at [ and only keep index 0
					var attrQuryParts:Array = sel.split( "[" );
					
					sel = attrQuryParts[ 0 ] as String;
					
					// Split at spaces
					var selectorNames:Array = sel.split( " " );
					
					for( var k:int = 0; k < selectorNames.length; k++ ){
						
						var selName:String = selectorNames[ k ] as String;
						
						if( selName == null || selName == "" ){
							
							continue;
							
						}
						
						// Check for direct class applications such as p.class-name
						var selDotIndex:int = selName.indexOf( ".", 1 );
						if( selDotIndex != -1 ){
							
							// Add the extra classes
							var dotParts:Array = selName.split( "." );
							
							for( var d:int = 0; d < dotParts.length; d++ ){
								
								var dotPrt:String = dotParts[ d ] as String;
								
								if( d > 0 ){
									
									dotPrt = "." + dotPrt;
									
									if( d == 1 && selName.indexOf( "." ) === 0 ){
										
										selName = dotPrt;
										
									}else{
										
										selectorNames.push( dotPrt );
										
									}
									
								}else{
									
									if( dotPrt != "" ){
										
										selName = dotPrt;
										
									}
									
								}
								
							}
							
						}
						
						// Only add unique items
						if( newSelectors.indexOf( selName ) == -1 ){
							
							// Avoid @ prefix && avoid *
							if( selName.charAt( 0 ) != "@" && selName != "*" ){
								
								newSelectors.push( selName );
								
								switch( selName.charAt( 0 ) ){
									
									case ".":
										classes.push( selName );
										break;
									
									case "#":
										ids.push( selName );
										break;
									
									default:
										elements.push( selName );
										break;
									
								}
								
							}
							
						}
						
					}
					
				}
				
			}
			
			if( includeElements ){
				
				newSelectorCollection.source = elements.sort().concat( ids.sort().concat( classes.sort() ) );
				
			}else{
				
				newSelectorCollection.source = ids.sort().concat( classes.sort() );
				
			}
			
			return newSelectorCollection;
			
		}
		
