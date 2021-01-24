    public float getCurrentY()
    {
        float CurrentY =  API.Extension.ReadFloat(Variables.CIT_PLAYER_Y_COORD);
        return CurrentY;
    }
    private void CITFlyingHeightTrackBar_Scroll_1(object sender, ScrollEventArgs e)
    {
        float current_num = getCurrentY();
    }
