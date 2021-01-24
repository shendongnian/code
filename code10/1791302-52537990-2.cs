        public static FormattedString ToFormattedString(this string xamlStr)
        {
            var toReturn = new FormattedString();
            if (string.IsNullOrWhiteSpace(xamlStr))
                return toReturn;
            Span span = null;
            using(var strReader = new StringReader(xamlStr))
            {
                using(var xmlReader = XmlReader.Create(strReader))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement())
                        {
                            switch (xmlReader.Name)
                            {
                                case "Span":
                                    span = new Span();
                                    while (xmlReader.MoveToNextAttribute())
                                    {
                                        switch (xmlReader.Name)
                                        {
                                            case "ForegroundColor":
                                                var color = xmlReader.Value;
                                                if (!string.IsNullOrEmpty(color))
                                                    span.ForegroundColor = (Color)_typeConverter.ConvertFromInvariantString(color);
                                                break;
                                        }
                                    }
                                    if (xmlReader.IsStartElement() || xmlReader.MoveToContent() == XmlNodeType.Element)
                                    {
                                        span.Text = xmlReader.ReadString();
                                        toReturn.Spans.Add(span ?? new Span());
                                    }    
                                    break;
                            }
                        }
                    }
                }    
            }
            return toReturn;
        }
