    enter code herewhile(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    charCount += line.Length + 1;
                    GetSteps(line, rootNode, (int) lineNumber, stepDict, charCount);
                    sb.Append(line);
                    sb.Append(Environment.NewLine);
                    lineNumber++;
                    if (lineNumber % 3500 == 0)///Add text in segments of 3500 lines to Viewer
                    {
                        txtLSTViewer.AppendText(sb.ToString());
                        sb.Remove(0, sb.Length);
                        int progress = (int)((71.198 * lineNumber + 200000) * 100 / length); ///Set Progress Bar Value
                        progbarOpenFile.Value = progress >= 100 ? 100 : progress; ///If Progress Bar is >= 100 -> Progress Bar Value = 100.  Else it equals progress.
                        Application.DoEvents();
                    }
                }
                txtLSTViewer.AppendText(sb.ToString()); //Clean up: Add last few lines if lines remaining < 3500, and hide progress bar and label.
