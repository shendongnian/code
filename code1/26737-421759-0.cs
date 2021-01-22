            string myStr = "Hello there..';,]';';., Get rid of Punction";
            var s = from ch in myStr
                    where !Char.IsPunctuation(ch)
                    select ch;
            var bytes = UnicodeEncoding.ASCII.GetBytes(s.ToArray());
            var stringResult = UnicodeEncoding.ASCII.GetString(bytes);
