    public static Svg LoadSVG(Stream SVGFile)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Svg));
                    using (TextReader reader = new StreamReader(SVGFile))
                    {
                        Svg result = (Svg)serializer.Deserialize(reader);
                        return result;
                    }
                }
