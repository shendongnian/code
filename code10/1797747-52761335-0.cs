     while ((standard_output = proc.StandardOutput.ReadLine()) != null)
            {
                if (standard_output.Contains("Are you sure (Y/y or N/n ):"))
                {
                    proc.StandardInput.WriteLine("Y");
                   string myReturn= proc.StandardInput.ReadLine();
                    break;
                }
            }
