    switch (e.KeyCode)
    {
        case Keys.Enter:
        {
            if (!txtAuto.Focused)
            {
                Save();
            }
            break;
        }
        case Keys.Escape:
        {
            if (!txtAuto.Focused)
            {
                Close();
            }
            break;
        }
    }
