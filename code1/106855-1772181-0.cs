	DataObject dataObject = new DataObject();
	string sourceData = "Some string data to store...";
	// Encode the source string into Unicode byte arrays.
	byte[] unicodeText = Encoding.Unicode.GetBytes(sourceData); // UTF-16
	byte[] utf8Text = Encoding.UTF8.GetBytes(sourceData);
	byte[] utf32Text = Encoding.UTF32.GetBytes(sourceData);
	// The DataFormats class does not provide data format fields for denoting
	// UTF-32 and UTF-8, which are seldom used in practice; the following strings 
	// will be used to identify these "custom" data formats.
	string utf32DataFormat = "UTF-32";
	string utf8DataFormat  = "UTF-8";
	// Store the text in the data object, letting the data object choose
	// the data format (which will be DataFormats.Text in this case).
	dataObject.SetData(sourceData);
	// Store the Unicode text in the data object.  Text data can be automatically
	// converted to Unicode (UTF-16 / UCS-2) format on extraction from the data object; 
	// Therefore, explicitly converting the source text to Unicode is generally unnecessary, and
	// is done here as an exercise only.
	dataObject.SetData(DataFormats.UnicodeText, unicodeText);
	// Store the UTF-8 text in the data object...
	dataObject.SetData(utf8DataFormat, utf8Text);
	// Store the UTF-32 text in the data object...
	dataObject.SetData(utf32DataFormat, utf32Text);
