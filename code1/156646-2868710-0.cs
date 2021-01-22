    // use a string builer, the += on that many strings increasing in size
    // is causing massive memory hoggage and very well could be part of your problem
    StringBuilder sb = new StringBuilder();
    
    // open a stream reader
    using (var reader = new StreamReader(@"C:\Test.txt"))
    {
        // read through the stream loading up the string builder
        while (!reader.EndOfStream)
        {
           sb.Append( reader.ReadLine() );
        }
    }
    
    // set the text and null the string builder for GC
    textBox1.Text = sb.ToString();
    sb = null;
