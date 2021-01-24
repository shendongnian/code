       var stringbuilder = new StringBuilder();
                        foreach (var item in lstUniversities)
                        {
                            stringbuilder.Append("<li>");
                            //stringbuilder.Add("<sup>1</sup>Harward University, USA");
                            stringbuilder.Append(item);
                            stringbuilder.Append("</li>");
                        }
