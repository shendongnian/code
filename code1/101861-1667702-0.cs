    string[] texts = GetAllLabels();
    ownerControl.Invoke(new Action(() =>
    {
      for (int i = 0; i < UpdatingControls.Count && i < texts.Count; i++)
      {
        UpdatingControls[i].Text = texts[i];
      }
    }));
