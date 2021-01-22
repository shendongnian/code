    protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !appClosing)
            {
                if (MessageBox.Show("¿Desea Salir realmente?\nLa factura aun no ha sido pagada por lo que volverá a la pantalla anterior y podrá seguir agregando productos") == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
