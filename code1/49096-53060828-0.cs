    for (int tempReg = 0; tempReg < reg.Matches(lines).Count; tempReg++)
                                {
                                    foreach (Match match in reg.Matches(lines))
                                    {
                                        var aStringBuilder = new StringBuilder(lines);
                                        aStringBuilder.Insert(startIndex, match.ToString().Replace(",", " ");
                                        lines[k] = aStringBuilder.ToString();
                                        tempReg = 0;
                                        break;
                                    }
                                }
