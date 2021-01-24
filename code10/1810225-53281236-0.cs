         private void validaControles()
            {
                for (int j = 0; j < listaMetodo.Count; j++)
                {
                    for (int k = 0; k < listaControlesValida.Count; k++)
                    {
    
    //just ignore this condition
                    
    
    if(listaMetodo[j].NombrePadre.Equals(listaControlesValida[k].Control) && listaControlesValida[k].Valida && listaMetodo[j].TextoControl.Equals("")){
    
                       listaControlesValida[k].ValidaText, null);
                            Control[] control = this.Controls.Find(listaMetodo[j].NombrePadre, true);
                            Type type = control[0].GetType();
                            
                           control[0].GetType().GetProperty("_ValidaMsg").SetValue(control[0], listaControlesValida[k].ValidaText, null);
                           control[0].GetType().GetProperty("_Valida").SetValue(control[0], true, null);
                        }
                    }
                }
            }
