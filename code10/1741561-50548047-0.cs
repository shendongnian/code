    public void Update_Datos(int ID)
    {
        int UserId = Convert.ToInt16((string)(Session["UserId"]));
        using (var db = new Entities())
        {
            Datos_Personales datos = db.Datos_Personales.FirstOrDefault(d => d.UserId == UserId && d.Id == ID));
            if(datos == null)
                return;
            datos.Fecha_de_nacimiento = Convert.ToDateTime(Fecha_de_nacimiento.Text);
            datos.Nombre_Completo = txt_Nombre_Completo.Text;
            datos.Identificacion = txt_Identificacion.Text;
            datos.Estado_civil = ddEstadoCivil.SelectedValue;
            datos.Telefono = txt_num_telefono.Text;
            datos.Departamento = ddDepartamento.SelectedValue;
            datos.Nacionalidad = Country.SelectedValue;
            datos.Salario_min_aceptado = ddSalario_min_aceptado.SelectedValue;
            datos.Titulo = txt_Titulo.Text;
            datos.Descripcion_Profesional = txt_Descripcion_Profesional.Text;
            datos.UserId = Convert.ToInt16(UserId);
            db.SaveChanges();
        }
    }
