           string result=String.Empty;
            Encoding ae = Encoding.GetEncoding(
                  Encoding.UTF8.EncodingName,
                  new EncoderExceptionFallback(), 
                  new DecoderExceptionFallback());
            try {
                result=ae.GetString(mybytes);
            }
            catch (DecoderFallbackException e)
            {
                //revert to some sensible default. Maybe the Ansi Code page for this environment?
                // This will use the substitution fallback mechanism, which usually replaces unknown characters with question marks.
                result=Encoding.Default.GetString(mybytes);
            }
 
