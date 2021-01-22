    void SetPlayerMute(int playerMixerNo, bool value)
    {
            Mixer mx = new Mixer();
            mx.MixerNo = playerMixerNo;
            DestinationLine dl = mx.GetDestination(Mixer.Playback);
            if (dl != null)
                foreach (MixerControl ctrl in dl.Controls)
                    if (ctrl is MixerMuteControl)
                    {
                        ((MixerMuteControl)ctrl).Value = (value) ? 1 : 0;
                        break;
                    }
    }
