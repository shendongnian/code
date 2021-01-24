    private void UpdateLabel(object sender, EventArgs e)
    {
        if (_itunes.CurrentTrack != null && _itunes.PlayerState == ITPlayerState.ITPlayerStatePlaying)
        {
            _itunes.Resume();
            label_Position.Text = _itunes.PlayerPositionMS.ToString();
        }
    }
