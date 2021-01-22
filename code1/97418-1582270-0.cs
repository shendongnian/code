    public void CreateList(SPFeatureReceiverProperties prop)
            {
                logger.Info("Creating list");
                using (SPWeb currentWeb = WebHelper.GetWeb(prop))
                {
                    try
                    {
                        SPList list = ListHelper.CreateList("Other Documents", "", "Rhb Other Documents List", true, currentWeb);
                        logger.Info("List created successfully");
    
                        logger.Info("Attaching content types");
                        list.ContentTypesEnabled = true;
                        list.Update();
                        list.ContentTypes.Add(currentWeb.ContentTypes["RhbOtherDocuments"]);
                        list.Update();
                        list.ContentTypes["Item"].Delete();
                        list.Update();
                        logger.Info("Content type attached");
                    }
                    catch (Exception e)
                    {
                        logger.Error("List creation failed", e);
                        Console.WriteLine(e);
                    }
                }
            }
