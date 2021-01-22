            Label lblText; //initialized elsewhere
        void AssignLabel(string text)
        {
           if (InvokeRequired)
           {
              BeginInvoke((Action<string>)AssignLabel, text);
              return;
           }
           lblText.Text = text;           
        }
