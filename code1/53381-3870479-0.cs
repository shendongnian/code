     // Reads a line. A line is defined as a sequence of characters followed by
     // a carriage return ('\r'), a line feed ('\n'), or a carriage return
     // immediately followed by a line feed. The resulting string does not
     // contain the terminating carriage return and/or line feed. The returned
     // value is null if the end of the input stream has been reached.
     //
     /// <include file='doc\myStreamReader.uex' path='docs/doc[@for="myStreamReader.ReadLine"]/*' />
     public override String ReadLine()
     {
              _lineLength = 0;
              //if (stream == null)
              //       __Error.ReaderClosed();
              if (charPos == charLen)
              {
                       if (ReadBuffer() == 0) return null;
              }
              StringBuilder sb = null;
              do
              {
                       int i = charPos;
                       do
                       {
                               char ch = charBuffer[i];
                               int EolChars = 0;
                               if (ch == '\r' || ch == '\n')
                               {
                                        EolChars = 1;
                                        String s;
                                        if (sb != null)
                                        {
                                                 sb.Append(charBuffer, charPos, i - charPos);
                                                 s = sb.ToString();
                                        }
                                        else
                                        {
                                                 s = new String(charBuffer, charPos, i - charPos);
                                        }
                                        charPos = i + 1;
                                        if (ch == '\r' && (charPos < charLen || ReadBuffer() > 0))
                                        {
                                                 if (charBuffer[charPos] == '\n')
                                                 {
                                                          charPos++;
                                                          EolChars = 2;
                                                 }
                                        }
                                        _lineLength = s.Length + EolChars;
                                        _bytesRead = _bytesRead + _lineLength;
                                        return s;
                               }
                               i++;
                       } while (i < charLen);
                       i = charLen - charPos;
                       if (sb == null) sb = new StringBuilder(i + 80);
                       sb.Append(charBuffer, charPos, i);
              } while (ReadBuffer() > 0);
              string ss = sb.ToString();
              _lineLength = ss.Length;
              _bytesRead = _bytesRead + _lineLength;
              return ss;
     }
