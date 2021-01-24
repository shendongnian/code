    private string receiveddata = string.Empty;
    private const int startIndex = 17;  // I had to change this from 16 based on the example string you gave.
    private const int length = 5;
    private const int totalLength = 34;  // The total length of the "line" of text we're expecting ("$abc,csd,frvt,v,00000,erty,9,gtyu*").
    private void serialPort1_DataReceived(object sender,            
      System.IO.Ports.SerialDataReceivedEventArgs e)
    {
      string receivedThisTime = serialPort1.ReadExisting();
      // Update the richTextBox that displays everything received.
      Invoke(new Action(() => displayAllReceivedText(receivedThisTime)));
      // Add what was just received to the string we're currently working on.
      receiveddata += receivedThisTime;
      // If we've received all of the characters in the complete line:
      // "$abc,csd,frvt,v,00000,erty,9,gtyu*", then we're ready to parse the
      // values we need from it.  This is a while in-case receiveddata contains
      // multiple complete lines - we want to parse them all.
      while (receiveddata.Length >= totalLength)
      {
        // Parse what we need from the string.
        string substring = receiveddata.Substring(startIndex, length);
        // Update the richtextbox that shows the parsed values.
        Invoke(new Action(() => displaySubText(substring)));
        // Now update our string to contain anything that comes after this
        // complete line.  i.e.
        // if receiveddata = "$abc,csd,frvt,v,00000,erty,9,gtyu*$abc,csd,"
        // it should now   = "$abc,csd,"
        receiveddata = receiveddata.Substring(totalLength);
      }
    }
    private void displayAllReceivedText(string text)
    {
      richTextBox2.AppendText(text);
    }
    private void displaySubText(string text)
    {
      richTextBox3.AppendText(text);
    }
