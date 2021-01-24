    public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
    {
        switch (keyCode)
        {
            case Keycode.Back:
                return true;
        }
    
        return base.OnKeyDown(keyCode, e);
    }
