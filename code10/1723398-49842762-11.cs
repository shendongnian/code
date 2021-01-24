	int charAsInt;
	var line = string.Empty;
	while(((charAsInt = reader.Read()) != -1)) {
		if (charAsInt >= 32) { //is a displayable character
			line = line + (char)charAsInt;
			
			//your code to handle the lines
			if(line.Contains("Hello!")) {
				writer.WriteLine("1.2.3.4"); // input for the next prompt
			} else if(line.Contains("Text1") {
				writer.WriteLine("2.3.4.5"); // input for next prompt of Text2
			}
			writer.Flush();
			//writer.WaitForPipeDrain();
		
		} else { //is a control character
			if (charAsInt == 10 || charAsInt == 13) { //carriage return or line feed; i.e. end of line
				if (line.Length > 0) {
					Debug.WriteLine("Last line read was {0}", line); //just so you can see info as it comes from the server
					line = string.Empty;
				}
			}
		}
    }
