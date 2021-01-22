			string[] lines = richTextBox1.Text.Split("\n".ToCharArray() );
			int lineToDelete = 2;			//O-based line number
			string richText = string.Empty;
			for ( int x = 0 ; x < lines.GetLength( 0 ) ; x++ )
			{
				if ( x != lineToDelete )
				{
					richText += lines[ x ];
					richText += Environment.NewLine;
				}
			}
			richTextBox1.Text = richText;
