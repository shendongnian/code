       public void LogResult ()
                    {
            
         using (StreamWriter sw = new StreamWriter(accessiblityTestFileLocation))
            {
                foreach (var path in appInfo.Pages)
                {
                    var navigateUrl = new Uri(baseUrl, path.Path);
    
                    driver.Navigate().GoToUrl(navigateUrl);
                    driverService.driver.Manage().Window.Maximize();
    
                    AxeResult results = driver.Analyze();
    
                    //Format the results, And write them in the text file.
                    if (results.Passes.Length > 0)
                    {
                        //Format the text as per your need, This text will be entered into the Text file.
                        sw.WriteLine("\n");
                        sw.WriteLine(path.Title);
                        sw.WriteLine("===========================");
                        sw.WriteLine("\n");
    
                        foreach (var passCase in results.Passes)
                        {
                            sw.WriteLine("Id: " + passCase.Id);
                            sw.WriteLine("Description: " + passCase.Description);
                            sw.WriteLine("Impact: " + "Normal");
                            sw.WriteLine("Help: " + passCase.Help);
                            sw.WriteLine("HelpURL: " + passCase.HelpUrl);
                            foreach (var node in passCase.Nodes)
                            {
                                sw.WriteLine(node.Html);
                                sw.WriteLine("\n");
                            }
                        }
                    }
    
                    //Format the results based on the result type, And write them in the text file.
                    if (results.Violations.Length > 0)
                    {
                        foreach (var violation in results.Violations)
                        {
                            //Write the accessibility test for the selected Attributes provided by the Axecore.
                            sw.WriteLine("Id: " + violation.Id);
                            sw.WriteLine("Description: " + violation.Description);
                            sw.WriteLine("Impact: " + violation.Impact);
                            sw.WriteLine("Help: " + violation.Help);
                            sw.WriteLine("HelpURL: " + violation.HelpUrl);
                            foreach (var node in violation.Nodes)
                            {
                                sw.WriteLine(node.Html);
                                sw.WriteLine("\n");
                            }
                        }
                    }
                }
            }
                    }
