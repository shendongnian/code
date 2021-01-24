        public static string RemoveStartAndEndBreaks(this string input)
        {
            var lineBreaks = new[] { "<br>", "<br/>", "<br />", "<p></p>", "<p> </p>", "<p>&nbsp;</p>", "<div></div>", "<div> </div>", "<div>&nbsp;</div>" };
            for (int i = 0; i < lineBreaks.Length; i++)
            {
                if (input == lineBreaks[i])
                {
                    //Do This
                }
                
            }
            return input;
        }
