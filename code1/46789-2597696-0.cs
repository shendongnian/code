        set
        {
            if (value != string.Empty)
            {
                MensajeError.Visible = true;
                MensajeError.InnerHtml = value;
            }
            else
                MensajeError.Visible = false;
        }
    }
