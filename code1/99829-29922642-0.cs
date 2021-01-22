     protected void gvofertas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            gvofertas.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                
                case "ELIMINAR":
                    {
                        //lblSolEliminar.Text = "Usuario: " + Convert.ToString(gvCorreos.DataKeys[gvCorreos.SelectedIndex].Values["etspcpusrn"]);
                        mpeEliminar.Show();
                        break;
                    }
                case "EDITAR":
                    {
                        Limpiar();
                        Session["NROOFERTAACTUALIZA"] = Convert.ToString(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophcodi"]).Trim();
                        txtDescripcion.Text = Convert.ToString(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophdesc"]).Trim();
                        StartDate.Text= Convert.ToDateTime(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophfini"]).ToShortDateString();
                        EndDate.Text = Convert.ToDateTime(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophffin"]).ToShortDateString();
                        txtRango1Localidades1Agregar.Text = Convert.ToString(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophloci"]).Trim();
                        txtRango2Localidades1Agregar.Text = Convert.ToString(gvofertas.DataKeys[gvofertas.SelectedIndex].Values["efophlocf"]).Trim();
                        this.mpeAgregar.Show();
                        BtnGuardar2.Text = "Actualizar";
                        txtDescripcion.Focus();
                        break;
                    }
                
        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", F.m_strImagenError, ex.Message);
        }
