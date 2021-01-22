    private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
    {
        foreach (Control item in Form.ActiveForm.Controls)
        {
            item.CausesValidation = false;
        }
    }
