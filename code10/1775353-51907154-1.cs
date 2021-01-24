    private void btn_rotate_Click(object sender, EventArgs e)
    {
        int step = 10;
        ChartArea ca = chart4.ChartAreas[0];
        if (sender == btn_reset) { ca.Area3DStyle.Rotation = 30;  ca.Area3DStyle.Inclination = 30; } 
        if (sender == btn_left && ca.Area3DStyle.Rotation < 180-step) ca.Area3DStyle.Rotation+= step;
        if (sender == btn_right && ca.Area3DStyle.Rotation > -180-step) ca.Area3DStyle.Rotation-= step;
        if (sender == btn_down && ca.Area3DStyle.Inclination < 90-step) ca.Area3DStyle.Inclination+= step;
        if (sender == btn_up && ca.Area3DStyle.Inclination > -90-step) ca.Area3DStyle.Inclination-= step;
    }
