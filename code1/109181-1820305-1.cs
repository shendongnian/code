         foreach (Control contrl in this.Controls)
         {
            if (contrl.GetType().GetProperty("Text") != null)
            {
               // contrl has Text Property
            }
         }
