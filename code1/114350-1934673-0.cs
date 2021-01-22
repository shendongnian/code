    XmlSerializer xmlSerializer = new XmlSerializer( typeof( Hero ) );
				using ( StringReader reader = new StringReader( xmlDataString ) )
				{
					Hero hero = ( Hero ) xmlSerializer.Deserialize( reader );
				}
		
