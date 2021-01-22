            XDocument xDoc = null;
            while (xDoc == null)
            {
                while (IsFileBeingUsed(_interactionXMLPath))
                {
                    Logger.WriteMessage(Logger.LogPrioritet.Warning, "Deserialize can not open XML file. is being used by another process. wait...");
                    Thread.Sleep(100);
                }
                try
                {
                    xDoc = XDocument.Load(_interactionXMLPath);
                }
                catch
                {
                    Logger.WriteMessage(Logger.LogPrioritet.Error, "Load working!!!!!");
                }
            }
