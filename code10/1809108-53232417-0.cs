    int start = inLine.IndexOf("'");
                        if (start >= 0)
                        {
                            inLine = inLine.Substring(start);
                            int end = inLine.IndexOf(" ");
                            string lastname = inLine.Substring(0, end);
                            inLine = inLine.Substring(end + 1);
                            int endTwo = inLine.IndexOf(" ");
                            string firstname = inLine.Substring(end, endTwo);
                            inLine = inLine.Substring(endTwo + 1);
                            int endThree = inLine.IndexOf(" ");
                            string email = inLine.Substring(endTwo, endThree);
                            .
                            .
                        }
