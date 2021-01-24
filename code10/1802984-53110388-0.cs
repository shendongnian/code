    int uiLevel;
                    if (int.TryParse(session["UI_LEVEL"], out uiLevel))
                    {
                        if (uiLevel == 4)
                            using (var form = new WhatsNew())
                            {
                                form.ShowDialog();
                            }
                        else
                            session.Log("Skipping What's new dialogue as UI Level is not 4");
    
                    }
                    else
                    {
                        session.Log("Couldnt figure out the UI level, so skipped the prompt");
                    }
