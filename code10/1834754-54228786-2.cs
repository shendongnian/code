    public static IEnumerator StartPitchMeter(Player.Guy guy, float duration)
    {
    
        do
        {
            yield return null;
            // Fill 50 units per second.
            float fillThisFrame = Time.deltaTime * 50f;
            PlayerControls.PitchMeter += fillThisFrame;
    
            if (PlayerControls.PitchMeter > 600) PlayerControls.PitchMeter = 0f;
    
            PlayerControls.pitchMeter.sizeDelta = new Vector2(PlayerControls.PitchMeter, 50);
            // Not sure what the 50 is doing here so it might be this instead:
            // PlayerControls.pitchMeter.sizeDelta = new Vector2(PlayerControls.PitchMeter, fillThisFrame);
    
        } while (!PlayerControls.stopPitch);
    
    }
