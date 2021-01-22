	    protected int _MeasureDisplayStringWidth ( Graphics graphics, string text, Font font )
		{
			if ( text == "" )
				return 0;
			StringFormat format = new StringFormat ( StringFormat.GenericDefault );
			RectangleF rect = new RectangleF ( 0, 0, 1000, 1000 );
			CharacterRange[] ranges = { new CharacterRange ( 0, text.Length ) };
			Region[] regions = new Region[1];
			format.SetMeasurableCharacterRanges ( ranges );
			format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			regions = graphics.MeasureCharacterRanges ( text, font, rect, format );
			rect = regions[0].GetBounds ( graphics );
			return (int)( rect.Right );
		}
