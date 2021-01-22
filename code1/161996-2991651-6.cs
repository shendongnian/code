     StringBuilder lSb = new StringBuilder();
                for (int i = 0; i < fileTextList.Count; i++)
                {
                    lSb.AppendLine(fileTextList[i]);
                }
                File.WriteAllText(@"C:/test2.txt",lSb.ToString());
