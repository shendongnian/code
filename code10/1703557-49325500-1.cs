    public static bool Compare(this GamePadState g1, GamePadState g2)
    {
        return (g1.IsConnected == g2.IsConnected &&
            g1.Buttons == g2.Buttons &&
            g1.DPad == g2.DPad &&
            g1.ThumbSticks == g2.ThumbSticks &&
            g1.Triggers == g2.Triggers);
    }
