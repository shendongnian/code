        private void readOutput()
        {
            do
            {
                string strOutput = shellStream.ReadLine();
                if (strOutput != null && strOutput.Length > 0)
                {
                    System.Console.WriteLine(strOutput);
                    this.SetStatusText(strOutput);
                }
                else
                {
                    break;
                }
            } while (true);
        }
