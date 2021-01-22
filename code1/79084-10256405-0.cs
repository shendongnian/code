    private void malla18_Mask_Validated(object sender, EventArgs e)
    {
      analisis_Tabla_Lote.Columns["SUMA_MALLAS"].Expression = "100 - (Malla12 + Malla14 + Malla15 + Malla16 + Malla17 + Malla18 )";
      analisis_BindingSource.ResetBindings(false);
    }
