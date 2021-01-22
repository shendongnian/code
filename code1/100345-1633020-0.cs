    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (listBox_Codigo.SelectedItem == null)
            {
                if (MessageBox.Show(this, "No se puede ingresar un producto sin seleccionarlo.\n ¿Desea intentarlo de nuevo, o Salir?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                var Principal = (PDQ.Cajero)this.ParentForm;
                Principal.CodigoInsertado = listBox_Codigo.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
       }
       catch (Exception ex)
       {
            MessageBox.Show(ex.ToString());
            //LogException(ex);
       }
    }
