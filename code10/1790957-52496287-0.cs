    public static class KeyHelpers
    {
        public static bool IsKeyPressedAny(params System.Windows.Input.Key[] keys)
        {
            foreach (var key in keys)
            {
                if (System.Windows.Input.Keyboard.IsKeyDown(k))
                {
                    return true;
                }
            }
            return false;
        }
    }
