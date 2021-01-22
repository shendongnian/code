    private void ShowPanel(string name)
    {
    
         // its easy to just hide all panels again if one is currently visible
         simulationPanel.Visible = false;
         delaysPanel.Visible = false;
         occurrencesPanel.Visible = false;
         languagePanel.Visible = false;
    
         if (name == "language")
         {
              languagePanel.Visible = true; 
         } else if (name = "delays")
         {
              delaysPanel.Visible = true;
         }
         ... etc
    }
